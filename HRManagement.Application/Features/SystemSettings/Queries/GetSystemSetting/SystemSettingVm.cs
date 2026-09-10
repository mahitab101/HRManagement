using System;
using System.Collections.Generic;

namespace HRManagement.Application.Features.SystemSettings.Queries.GetSystemSetting
{
    public class SystemSettingVm
    {
        public Guid? BranchId { get; set; }
        public List<DayOfWeek> WeekendDays { get; set; } = new();
        public decimal WorkingHoursPerDay { get; set; }
    }
}