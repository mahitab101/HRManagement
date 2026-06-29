using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Branch.Queries.GetBranchByDetails
{
    public class EmployeeSummaryVm
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
