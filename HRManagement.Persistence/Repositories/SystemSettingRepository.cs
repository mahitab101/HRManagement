using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain.Entities;
using HRManagement.Persistence.Data;
using HRManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HRManagement.Persistence.Repositories
{
    public class SystemSettingRepository : BaseRepository<SystemSetting>, ISystemSettingRepository
    {
        public SystemSettingRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<SystemSetting?> GetByBranchIdAsync(Guid? branchId)
        {
            return await _dbContext.SystemSettings
                .FirstOrDefaultAsync(s => s.BranchId == branchId);
        }
    }
}