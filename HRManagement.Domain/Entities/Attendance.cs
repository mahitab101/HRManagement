using HRManagement.Domain.Common;
using HRManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Domain.Entities
{
    public class Attendance:AuditableEntity
    {
        public Guid EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public AttendanceStatus Status { get; set; }

        public Employee Employee { get; set; }
    }
}
