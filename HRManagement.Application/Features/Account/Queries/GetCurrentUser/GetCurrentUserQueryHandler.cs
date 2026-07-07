using HRManagement.Application.Contracts.Identity;
using HRManagement.Application.Responses;
using MediatR;

namespace HRManagement.Application.Features.Account.Queries.GetCurrentUser
{
    public class GetCurrentUserQueryHandler
        : IRequestHandler<GetCurrentUserQuery, BaseResponse<CurrentUserDto>>
    {
        private readonly ICurrentUserService _currentUserService;

        public GetCurrentUserQueryHandler(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public Task<BaseResponse<CurrentUserDto>> Handle(
            GetCurrentUserQuery request,
            CancellationToken cancellationToken)
        {
            var dto = new CurrentUserDto
            {
                Email = _currentUserService.Email ?? string.Empty,
                EmployeeId = _currentUserService.EmployeeId,
                Roles = _currentUserService.Roles.ToList()
            };

            return Task.FromResult(
                BaseResponse<CurrentUserDto>.SuccessResponse(dto, "Current user retrieved successfully.")
            );
        }
    }
}