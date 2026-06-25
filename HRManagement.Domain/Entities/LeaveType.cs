using HRManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Domain.Entities
{
    public class LeaveType:AuditableEntity
    {
        public string Name { get; set; }
        public int MaxDaysPerYear { get; set; }
    }
}
