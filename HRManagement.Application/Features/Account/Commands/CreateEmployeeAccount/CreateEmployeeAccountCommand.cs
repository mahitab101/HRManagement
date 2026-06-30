using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Account.Commands.CreateEmployeeAccount
{
    public class CreateEmployeeAccountCommand : IRequest<BaseResponse<CreateEmployeeAccountCommandResponse>>
    {
        public Guid EmployeeId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
