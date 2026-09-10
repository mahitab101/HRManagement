using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Contracts.Persistence
{
    public interface IWorkingDaysCalculator
    {
        Task<int> CalculateWorkingDaysAsync(Guid employeeId, DateTime startDate, DateTime endDate);
    }
}
