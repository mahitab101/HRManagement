using HRManagement.Application.Contracts.Identity;
using HRManagement.Application.Models.Identity;
using HRManagement.Application.Responses;
using MediatR;

namespace HRManagement.Application.Features.Account.Commands.CreateEmployeeAccount
{
    public class CreateEmployeeAccountCommandHandler
        : IRequestHandler<CreateEmployeeAccountCommand, BaseResponse<CreateEmployeeAccountCommandResponse>>
    {
        private readonly IAccountService _accountService;

        public CreateEmployeeAccountCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<BaseResponse<CreateEmployeeAccountCommandResponse>> Handle(
            CreateEmployeeAccountCommand request,
            CancellationToken cancellationToken)
        {
            var dto = new CreateEmployeeAccountDto
            {
                EmployeeId = request.EmployeeId,
                Email = request.Email,
                Password = request.Password
            };

            var result = await _accountService.CreateEmployeeAccountAsync(dto);
            //TODO:Send email to the employee with his credentials
            var response = new CreateEmployeeAccountCommandResponse
            {
                Email = result.Email,
                EmployeeId = result.EmployeeId
            };

            return BaseResponse<CreateEmployeeAccountCommandResponse>.SuccessResponse(
                response, "Employee account created successfully.");
        }
    }
}