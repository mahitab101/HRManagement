using HRManagement.Application.Common.Constants;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Models.Identity;
using HRManagement.Domain.Identity;
using HRManagement.Application.Contracts.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Infrastructure.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IEmployeeRepository _employeeRepository;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService,
            IEmployeeRepository employeeRepository)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _employeeRepository = employeeRepository;
        }

        public async Task<AuthResponseDto> CreateEmployeeAccountAsync(CreateEmployeeAccountDto request)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);
            if (employee == null)
                throw new KeyNotFoundException($"Employee with Id {request.EmployeeId} not found.");

            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
                throw new InvalidOperationException("An account with this email already exists.");

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                EmployeeId = request.EmployeeId
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to create account: {errors}");
            }

            await _userManager.AddToRoleAsync(user, Roles.Employee);

            var roles = await _userManager.GetRolesAsync(user);
            var token = await _tokenService.GenerateTokenAsync(user, roles);

            return new AuthResponseDto
            {
                Token = token,
                Email = user.Email!,
                EmployeeId = user.EmployeeId
            };
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return null;

            var validPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!validPassword)
                return null;

            var roles = await _userManager.GetRolesAsync(user);
            var token = await _tokenService.GenerateTokenAsync(user, roles);

            return new AuthResponseDto
            {
                Token = token,
                Email = user.Email!,
                EmployeeId = user.EmployeeId
            };
        }

        public async Task<bool> AssignRoleAsync(Guid userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            if (await _userManager.IsInRoleAsync(user, role))
                throw new InvalidOperationException($"User already has the '{role}' role.");

            var result = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to assign role: {errors}");
            }

            return true;
        }

        public async Task<bool> RemoveRoleAsync(Guid userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            if (!await _userManager.IsInRoleAsync(user, role))
                throw new InvalidOperationException($"User does not have the '{role}' role.");

            var result = await _userManager.RemoveFromRoleAsync(user, role);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to remove role: {errors}");
            }

            return true;
        }
    }
}

