using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Account.Queries.GetUserRoles
{
    public class GetUserRolesQuery : IRequest<BaseResponse<GetUserRolesVm>>
    {
        public Guid UserId { get; set; }
    }
}
