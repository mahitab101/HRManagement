using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Contracts
{
    public interface ILeaveBalanceService
    {
        Task InitializeBalancesForEmployeeAsync(Guid employeeId, DateTime hireDate);
        Task<bool> HasSufficientBalanceAsync(Guid employeeId, Guid leaveTypeId, int requestedDays, int year);
        Task HoldBalanceAsync(Guid employeeId, Guid leaveTypeId, int days, int year);
        Task ReleaseHoldAsync(Guid employeeId, Guid leaveTypeId, int days, int year);
        Task ConfirmBalanceAsync(Guid employeeId, Guid leaveTypeId, int days, int year);
        Task RestoreBalanceAsync(Guid employeeId, Guid leaveTypeId, int days, int year);
        Task RunYearlyRolloverAsync(int year);
    }
}
