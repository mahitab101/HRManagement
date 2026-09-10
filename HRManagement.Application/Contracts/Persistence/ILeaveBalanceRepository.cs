using HRManagement.Domain.Entities;

namespace HRManagement.Application.Contracts.Persistence
{
    public interface ILeaveBalanceRepository : IBaseRepository<LeaveBalance>
    {
        Task<IReadOnlyList<LeaveBalance>> GetAllByEmployeeAsync(Guid employeeId);
        Task<IReadOnlyList<LeaveBalance>> GetByEmployeeAsync(Guid employeeId, int year);
        Task<LeaveBalance?> GetByEmployeeAndLeaveTypeAsync(Guid employeeId, Guid leaveTypeId, int year);
    }
}