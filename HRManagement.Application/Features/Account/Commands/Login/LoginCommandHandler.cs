using HRManagement.Application.Contracts.Identity;
using HRManagement.Application.Models.Identity;
using HRManagement.Application.Responses;
using MediatR;

namespace HRManagement.Application.Features.Account.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, BaseResponse<LoginCommandResponse>>
    {
        private readonly IAccountService _accountService;

        public LoginCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<BaseResponse<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginDto = new LoginDto
            {
                Email = request.Email,
                Password = request.Password
            };

            var result = await _accountService.LoginAsync(loginDto);

            if (result == null)
                return BaseResponse<LoginCommandResponse>.FailureResponse("Invalid email or password.");

            var response = new LoginCommandResponse
            {
                Token = result.Token,
                Email = result.Email,
                EmployeeId = result.EmployeeId
            };

            return BaseResponse<LoginCommandResponse>.SuccessResponse(response, "Login successful.");
        }
    }
}