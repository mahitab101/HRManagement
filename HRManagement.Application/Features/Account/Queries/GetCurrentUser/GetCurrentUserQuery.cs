using HRManagement.Application.Responses;
using MediatR;

namespace HRManagement.Application.Features.Account.Queries.GetCurrentUser
{
    public class GetCurrentUserQuery : IRequest<BaseResponse<CurrentUserDto>>
    {
    }
}