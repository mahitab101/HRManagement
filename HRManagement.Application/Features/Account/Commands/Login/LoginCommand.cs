using HRManagement.Application.Models.Identity;
using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Account.Commands.Login
{
    public class LoginCommand : IRequest<BaseResponse<LoginCommandResponse>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
