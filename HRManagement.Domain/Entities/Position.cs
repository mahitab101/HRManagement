using HRManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Domain.Entities
{
    public class Position:AuditableEntity
    {
        public string Title { get; set; }=string.Empty;
        public Guid DepartmentId { get; set; }
        public decimal BaseSalary { get; set; }
        public Department Department { get; set; }
    }
}
