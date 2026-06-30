using HRManagement.Application.Contracts.Identity;
using HRManagement.Application.Responses;
using MediatR;

namespace HRManagement.Application.Features.Account.Commands.AssignRole
{
    public class AssignRoleCommandHandler
        : IRequestHandler<AssignRoleCommand, BaseResponse<AssignRoleCommandResponse>>
    {
        private readonly IAccountService _accountService;

        public AssignRoleCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<BaseResponse<AssignRoleCommandResponse>> Handle(
            AssignRoleCommand request,
            CancellationToken cancellationToken)
        {
            await _accountService.AssignRoleAsync(request.UserId, request.Role);

            var response = new AssignRoleCommandResponse
            {
                UserId = request.UserId,
                Role = request.Role
            };

            return BaseResponse<AssignRoleCommandResponse>.SuccessResponse(
                response, $"Role '{request.Role}' assigned successfully.");
        }
    }
}