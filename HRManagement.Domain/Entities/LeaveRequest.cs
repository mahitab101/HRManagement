using HRManagement.Domain.Common;
using HRManagement.Domain.Enums;
using System;

namespace HRManagement.Domain.Entities
{
    public class LeaveRequest : AuditableEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RequestedDays { get; set; }
        public LeaveStatus Status { get; set; }
        public Guid? ApproverId { get; set; }
        public string? Notes { get; set; }

        public Employee Employee { get; set; }
        public LeaveType LeaveType { get; set; }
    }
}