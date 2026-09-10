using HRManagement.Application.Contracts;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings;
using HRManagement.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseResponse<CreateEmployeeCommandResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILeaveBalanceService _leaveBalanceService;

        public CreateEmployeeCommandHandler(
            IEmployeeRepository employeeRepository,
            ILeaveBalanceService leaveBalanceService)
        {
            _employeeRepository = employeeRepository;
            _leaveBalanceService = leaveBalanceService;
        }

        public async Task<BaseResponse<CreateEmployeeCommandResponse>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = request.ToEntity();
            var newEmplyee = await _employeeRepository.AddAsync(employee);

            await _leaveBalanceService.InitializeBalancesForEmployeeAsync(newEmplyee.Id, newEmplyee.HireDate);

            var response = new CreateEmployeeCommandResponse() { Id = newEmplyee.Id };

            return BaseResponse<CreateEmployeeCommandResponse>.SuccessResponse(response, "Employee created successfully");
        }
    }
}