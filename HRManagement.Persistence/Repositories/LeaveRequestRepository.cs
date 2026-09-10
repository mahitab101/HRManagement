using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain.Entities;
using HRManagement.Domain.Enums;
using HRManagement.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : BaseRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<LeaveRequest>> GetAllWithDetailsAsync()
        {
            return await _dbContext.LeaveRequests
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .ToListAsync();
        }

        public async Task<bool> HasOverlappingRequestAsync(Guid employeeId, DateTime startDate, DateTime endDate)
        {
            return await _dbContext.LeaveRequests.AnyAsync(l =>
                l.EmployeeId == employeeId &&
                l.Status != LeaveStatus.Rejected &&
                l.StartDate <= endDate &&
                l.EndDate >= startDate);
        }
    }
}