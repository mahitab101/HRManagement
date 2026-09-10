using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain.Entities;
using HRManagement.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Persistence.Repositories
{
    public class LeaveBalanceRepository : BaseRepository<LeaveBalance>, ILeaveBalanceRepository
    {
        public LeaveBalanceRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<LeaveBalance?> GetByEmployeeAndLeaveTypeAsync(
            Guid employeeId, Guid leaveTypeId, int year)
        {
            return await _dbContext.LeaveBalances
                .FirstOrDefaultAsync(lb =>
                    lb.EmployeeId == employeeId &&
                    lb.LeaveTypeId == leaveTypeId &&
                    lb.Year == year);
        }

        public async Task<IReadOnlyList<LeaveBalance>> GetAllByEmployeeAsync(Guid employeeId)
        {
            return await _dbContext.LeaveBalances
                .Include(lb => lb.LeaveType)
                .Where(lb => lb.EmployeeId == employeeId)
                .OrderByDescending(lb => lb.Year)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<LeaveBalance>> GetByEmployeeAsync(Guid employeeId, int year)
        {
            return await _dbContext.LeaveBalances
                .Include(lb => lb.LeaveType)
                .Where(lb => lb.EmployeeId == employeeId && lb.Year == year)
                .ToListAsync();
        }
    }
}