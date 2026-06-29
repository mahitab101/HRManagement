using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain.Entities;
using HRManagement.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Persistence.Repositories
{
    public class LeaveRequestRepository:BaseRepository<LeaveRequest>, ILeaveRequestRepository
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
    }
}
