using HRManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Domain.Entities
{
    public class EmployeeTransferHistory : AuditableEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid FromBranchId { get; set; }
        public Guid ToBranchId { get; set; }
        public DateTime TransferDate { get; set; }
        public string Reason { get; set; }

        public Employee Employee { get; set; }
        public Branch FromBranch { get; set; }
        public Branch ToBranch { get; set; }
    }
}
