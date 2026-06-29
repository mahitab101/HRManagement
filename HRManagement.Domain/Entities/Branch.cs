using HRManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Domain.Entities
{
    public class Branch : AuditableEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public Guid? ManagerId { get; set; }
        public Employee? Manager { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
