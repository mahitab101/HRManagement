using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Models.Identity
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid? EmployeeId { get; set; }
    }
}
