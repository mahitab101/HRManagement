using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, BaseResponse<bool>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);

            if (employee == null)
                return BaseResponse<bool>.FailureResponse($"Employee with Id {request.Id} not found");

            // DeleteAsync بترفع EntityState.Deleted، والـ AppDbContext.SaveChangesAsync()
            // override بتاعتنا بتحوّلها تلقائياً لـ Soft Delete (IsDeleted = true)
            await _employeeRepository.DeleteAsync(employee);

            return BaseResponse<bool>.SuccessResponse(true, "Employee deleted successfully");
        }
    }
}
