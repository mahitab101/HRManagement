using HRManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Contracts.Persistence
{
    public interface IEmployeeTransferHistoryRepository:IBaseRepository<EmployeeTransferHistory>
    {
        Task<IReadOnlyList<EmployeeTransferHistory>> GetByEmployeeIdAsync(Guid employeeId);
    }
}
