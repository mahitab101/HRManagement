using HRManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Domain.Entities
{
    public class Department:AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public Guid? ManagerId { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Position>? Positions { get; set; }
    }
}
