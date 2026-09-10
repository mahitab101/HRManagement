using HRManagement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace HRManagement.Application.Contracts
{
    public interface ISystemSettingService
    {
        Task<SystemSetting> GetSettingsForBranchAsync(Guid branchId);
        Task<SystemSetting> GetGlobalSettingsAsync();
    }
}