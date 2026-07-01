using HRManagement.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Contracts.Identity
{
    public interface IAccountService
    {
        Task<AuthResponseDto> CreateEmployeeAccountAsync(CreateEmployeeAccountDto request);
        Task<AuthResponseDto?> LoginAsync(LoginDto request);
        Task<bool> AssignRoleAsync(Guid userId, string role);
        Task<bool> RemoveRoleAsync(Guid userId, string role);
    }
}
