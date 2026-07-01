using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Account.Commands.RemoveRole
{
    public class RemoveRoleCommandResponse
    {
        public Guid UserId { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
