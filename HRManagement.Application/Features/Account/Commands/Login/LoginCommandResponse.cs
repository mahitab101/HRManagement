using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Account.Commands.Login
{
    public class LoginCommandResponse
    {
        public string Token { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid? EmployeeId { get; set; }
    }
}
