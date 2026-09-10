using HRManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Domain.Entities
{
    public class SystemSetting : AuditableEntity

    {
        public Guid? BranchId { get; set; }
        public Branch? Branch { get; set; }

        public List<DayOfWeek> WeekendDays { get; set; } = new() { DayOfWeek.Friday, DayOfWeek.Saturday };
        public decimal WorkingHoursPerDay { get; set; } = 8;
    }
}
