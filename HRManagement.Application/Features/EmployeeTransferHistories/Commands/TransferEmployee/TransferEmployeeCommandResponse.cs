using System;

namespace HRManagement.Application.Features.EmployeeTransferHistories.Commands.TransferEmployee
{
    public class TransferEmployeeCommandResponse
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid FromBranchId { get; set; }
        public Guid ToBranchId { get; set; }
    }
}
