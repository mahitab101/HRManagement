using HRManagement.Application.Contracts.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Infrastructure.Services.Account
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;
        public Guid? UserId
        {
            get
            {
                var value = User?.FindFirstValue(ClaimTypes.NameIdentifier) ??
                            User?.FindFirstValue("sub");
                return Guid.TryParse(value, out var id) ? id : null;
            }
        }

        public string? Email =>
          User?.FindFirstValue(ClaimTypes.Email) ??
          User?.FindFirstValue("email");

        public Guid? EmployeeId
        {
            get
            {
                var value = User?.FindFirstValue("EmployeeId");
                return Guid.TryParse(value, out var id) ? id : null;
            }
        }

        public IList<string> Roles =>
      User?.FindAll(ClaimTypes.Role)
           .Select(c => c.Value)
           .ToList()
      ?? new List<string>();
    }
}
