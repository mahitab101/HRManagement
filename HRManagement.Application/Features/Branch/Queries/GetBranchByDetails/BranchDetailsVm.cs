using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Branch.Queries.GetBranchByDetails
{
    public class BranchDetailsVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public Guid? ManagerId { get; set; }
        public string? ManagerName { get; set; }
        public int EmployeesCount { get; set; }
        public List<EmployeeSummaryVm> Employees { get; set; } = new();
    }
}
