using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Responses;
using MediatR;

namespace HRManagement.Application.Features.LeaveBalances.Queries.GetEmployeeLeaveBalances
{
    public class GetEmployeeLeaveBalancesQueryHandler
        : IRequestHandler<GetEmployeeLeaveBalancesQuery, BaseResponse<List<LeaveBalanceVm>>>
    {
        private readonly ILeaveBalanceRepository _leaveBalanceRepository;

        public GetEmployeeLeaveBalancesQueryHandler(ILeaveBalanceRepository leaveBalanceRepository)
        {
            _leaveBalanceRepository = leaveBalanceRepository;
        }

        public async Task<BaseResponse<List<LeaveBalanceVm>>> Handle(
      GetEmployeeLeaveBalancesQuery request,
      CancellationToken cancellationToken)
        {
            var balances = await _leaveBalanceRepository.GetAllByEmployeeAsync(request.EmployeeId);

            var vms = balances.Select(b => new LeaveBalanceVm
            {
                Id = b.Id,
                LeaveTypeId = b.LeaveTypeId,
                LeaveTypeName = b.LeaveType?.Name ?? string.Empty,
                TotalDays = b.TotalDays,
                UsedDays = b.UsedDays,
                RemainingDays = b.RemainingDays,
                PendingDays = b.PendingDays,
                Year = b.Year
            }).ToList();

            return BaseResponse<List<LeaveBalanceVm>>.SuccessResponse(
                vms, "Leave balances retrieved successfully.");
        }
    }
}