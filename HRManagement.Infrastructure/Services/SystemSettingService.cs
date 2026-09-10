using HRManagement.Application.Contracts;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRManagement.Infrastructure.Services
{
    public class SystemSettingService : ISystemSettingService
    {
        private readonly ISystemSettingRepository _systemSettingRepository;

        public SystemSettingService(ISystemSettingRepository systemSettingRepository)
        {
            _systemSettingRepository = systemSettingRepository;
        }

        public async Task<SystemSetting> GetSettingsForBranchAsync(Guid branchId)
        {
            var branchSettings = await _systemSettingRepository.GetByBranchIdAsync(branchId);
            return branchSettings ?? await GetGlobalSettingsAsync();
        }

        public async Task<SystemSetting> GetGlobalSettingsAsync()
        {
            var globalSettings = await _systemSettingRepository.GetByBranchIdAsync(null);
            if (globalSettings != null)
                return globalSettings;

            var defaultSettings = new SystemSetting
            {
                BranchId = null,
                WeekendDays = new List<DayOfWeek> { DayOfWeek.Friday, DayOfWeek.Saturday },
                WorkingHoursPerDay = 8
            };

            return await _systemSettingRepository.AddAsync(defaultSettings);
        }
    }
}