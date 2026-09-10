using HRManagement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace HRManagement.Application.Contracts.Persistence
{
    public interface ISystemSettingRepository : IBaseRepository<SystemSetting>
    {
        Task<SystemSetting?> GetByBranchIdAsync(Guid? branchId);
    }
}