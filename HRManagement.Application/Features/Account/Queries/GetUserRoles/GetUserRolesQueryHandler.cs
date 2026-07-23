using HRManagement.Application.Contracts.Identity;
using HRManagement.Application.Responses;
using MediatR;

namespace HRManagement.Application.Features.Account.Queries.GetUserRoles
{
    public class GetUserRolesQueryHandler
        : IRequestHandler<GetUserRolesQuery, BaseResponse<GetUserRolesVm>>
    {
        private readonly IAccountService _accountService;

        public GetUserRolesQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<BaseResponse<GetUserRolesVm>> Handle(
            GetUserRolesQuery request,
            CancellationToken cancellationToken)
        {
            var roles = await _accountService.GetUserRolesAsync(request.UserId);

            return BaseResponse<GetUserRolesVm>.SuccessResponse(
                new GetUserRolesVm { Roles = roles },
                "User roles retrieved successfully."
            );
        }
    }
}