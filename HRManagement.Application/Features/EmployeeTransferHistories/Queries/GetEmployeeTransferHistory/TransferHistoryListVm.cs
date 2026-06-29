using System;

namespace HRManagement.Application.Features.EmployeeTransferHistories.Queries.GetEmployeeTransferHistory
{
    public class TransferHistoryListVm
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public Guid FromBranchId { get; set; }
        public string? FromBranchName { get; set; }
        public Guid ToBranchId { get; set; }
        public string? ToBranchName { get; set; }
        public DateTime TransferDate { get; set; }
        public string? Reason { get; set; }
    }
}
