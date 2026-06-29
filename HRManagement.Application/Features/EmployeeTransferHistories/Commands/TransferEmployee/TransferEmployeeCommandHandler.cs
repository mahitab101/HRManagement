using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Responses;
using HRManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.EmployeeTransferHistories.Commands.TransferEmployee
{
    public class TransferEmployeeCommandHandler : IRequestHandler<TransferEmployeeCommand, BaseResponse<TransferEmployeeCommandResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeTransferHistoryRepository _transferHistoryRepository;

        public TransferEmployeeCommandHandler(
            IEmployeeRepository employeeRepository,
            IEmployeeTransferHistoryRepository transferHistoryRepository)
        {
            _employeeRepository = employeeRepository;
            _transferHistoryRepository = transferHistoryRepository;
        }

        public async Task<BaseResponse<TransferEmployeeCommandResponse>> Handle(TransferEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Check the employee
            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);

            if (employee == null)
                return BaseResponse<TransferEmployeeCommandResponse>.FailureResponse($"Employee with Id {request.EmployeeId} not found");

            // Check if the employee is not in the branch
            if (employee.BranchId == request.ToBranchId)
                return BaseResponse<TransferEmployeeCommandResponse>.FailureResponse("Employee is already assigned to this branch");

            var fromBranchId = employee.BranchId; 

            var transferRecord = new EmployeeTransferHistory
            {
                EmployeeId = employee.Id,
                FromBranchId = fromBranchId,
                ToBranchId = request.ToBranchId,
                TransferDate = request.TransferDate,
                Reason = request.Reason
            };

            await _transferHistoryRepository.AddAsync(transferRecord);

            // Update the branch for employee
            employee.BranchId = request.ToBranchId;
            await _employeeRepository.UpdateAsync(employee);

            var response = new TransferEmployeeCommandResponse
            {
                Id = transferRecord.Id,
                EmployeeId = employee.Id,
                FromBranchId = fromBranchId,
                ToBranchId = request.ToBranchId
            };

            return BaseResponse<TransferEmployeeCommandResponse>.SuccessResponse(response, "Employee transferred successfully");
        }
    }
}
