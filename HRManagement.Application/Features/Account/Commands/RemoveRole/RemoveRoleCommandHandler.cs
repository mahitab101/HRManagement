using HRManagement.Application.Contracts.Identity;
using HRManagement.Application.Responses;
using MediatR;

namespace HRManagement.Application.Features.Account.Commands.RemoveRole
{
    public class RemoveRoleCommandHandler
        : IRequestHandler<RemoveRoleCommand, BaseResponse<RemoveRoleCommandResponse>>
    {
        private readonly IAccountService _accountService;

        public RemoveRoleCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<BaseResponse<RemoveRoleCommandResponse>> Handle(
            RemoveRoleCommand request,
            CancellationToken cancellationToken)
        {
            await _accountService.RemoveRoleAsync(request.UserId, request.Role);

            var response = new RemoveRoleCommandResponse
            {
                UserId = request.UserId,
                Role = request.Role
            };

            return BaseResponse<RemoveRoleCommandResponse>.SuccessResponse(
                response, $"Role '{request.Role}' removed successfully.");
        }
    }
}