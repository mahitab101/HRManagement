using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, BaseResponse<bool>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);

            if (employee == null)
                return BaseResponse<bool>.FailureResponse($"Employee with Id {request.Id} not found");

            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.Phone = request.Phone;
            employee.NationalId = request.NationalId;
            employee.Gender = request.Gender;
            employee.DateOfBirth = request.DateOfBirth;
            employee.Status = request.Status;
            employee.DepartmentId = request.DepartmentId;
            employee.PositionId = request.PositionId;
            employee.BranchId = request.BranchId;

            await _employeeRepository.UpdateAsync(employee);

            return BaseResponse<bool>.SuccessResponse(true, "Employee updated successfully");
        }
    }
}
