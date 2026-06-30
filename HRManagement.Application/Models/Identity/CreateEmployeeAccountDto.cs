using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Models.Identity
{
    public class CreateEmployeeAccountDto
    {
        public Guid EmployeeId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
