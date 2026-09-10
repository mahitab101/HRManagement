using HRManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Domain.Entities
{
    public class LeaveBalance:AuditableEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid LeaveTypeId { get; set; }
        public int Year { get; set; }
        public int TotalDays { get; set; }
        public int UsedDays { get; set; }
        public int RemainingDays { get; set; }
        public int PendingDays { get; set; }
        public int AvailableDays => TotalDays - UsedDays - PendingDays;

        // Navigation Properties
        public Employee Employee { get; set; } = null!;
        public LeaveType LeaveType { get; set; } = null!;
    }
}
