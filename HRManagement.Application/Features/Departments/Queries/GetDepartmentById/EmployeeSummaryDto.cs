using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Departments.Queries.GetDepartmentById
{
    public class EmployeeSummaryDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PositionTitle { get; set; }
    }
}
