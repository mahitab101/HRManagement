using HRManagement.Application.Responses;
using HRManagement.Domain.Entities;
using MediatR;

namespace HRManagement.Application.Features.LeaveBalances.Queries.GetEmployeeLeaveBalances
{
    public class GetEmployeeLeaveBalancesQuery : IRequest<BaseResponse<List<LeaveBalanceVm>>>
    {
        public Guid EmployeeId { get; set; }
    }
}