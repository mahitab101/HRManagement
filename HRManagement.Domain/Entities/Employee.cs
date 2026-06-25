using HRManagement.Domain.Common;
using HRManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HRManagement.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NationalId { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public EmployeeStatus Status { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid PositionId { get; set; }
        public Guid BranchId { get; set; }

        // Navigation Properties
        public Department Department { get; set; }
        public Position Position { get; set; }
        public Branch Branch { get; set; }
    }
}

