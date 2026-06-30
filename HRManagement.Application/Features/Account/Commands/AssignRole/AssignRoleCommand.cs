using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Account.Commands.AssignRole
{
    public class AssignRoleCommand : IRequest<BaseResponse<AssignRoleCommandResponse>>
    {
        public Guid UserId { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
