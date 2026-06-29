using HRManagement.Application.Features.EmployeeTransferHistories.Queries.GetEmployeeTransferHistory;
using HRManagement.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HRManagement.Application.Mappings.EmployeeTransferHistories
{
    public static class EmployeeTransferHistoryMappingExtensions
    {
        public static TransferHistoryListVm ToTransferHistoryListVm(this EmployeeTransferHistory history)
        {
            return new TransferHistoryListVm
            {
                Id = history.Id,
                EmployeeId = history.EmployeeId,
                EmployeeName = history.Employee != null
                    ? $"{history.Employee.FirstName} {history.Employee.LastName}"
                    : null,
                FromBranchId = history.FromBranchId,
                FromBranchName = history.FromBranch?.Name,
                ToBranchId = history.ToBranchId,
                ToBranchName = history.ToBranch?.Name,
                TransferDate = history.TransferDate,
                Reason = history.Reason
            };
        }

        public static List<TransferHistoryListVm> ToTransferHistoryListVms(this IEnumerable<EmployeeTransferHistory> histories)
        {
            return histories.Select(h => h.ToTransferHistoryListVm()).ToList();
        }
    }
}