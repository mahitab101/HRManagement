using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain.Entities;
using HRManagement.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Persistence.Repositories
{
    public class EmployeeTransferHistoryRepository:BaseRepository<EmployeeTransferHistory>,IEmployeeTransferHistoryRepository
    {
        public EmployeeTransferHistoryRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<IReadOnlyList<EmployeeTransferHistory>> GetByEmployeeIdAsync(Guid employeeId)
        {
            return await _dbContext.EmployeeTransferHistories
                .Include(t => t.Employee)
                .Include(t => t.FromBranch)
                .Include(t => t.ToBranch)
                .Where(t => t.EmployeeId == employeeId)
                .OrderByDescending(t => t.TransferDate)
                .ToListAsync();
        }
    }
}
