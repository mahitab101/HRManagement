using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Models.Identity
{
    public class AssignRoleDto
    {
        public Guid UserId { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
