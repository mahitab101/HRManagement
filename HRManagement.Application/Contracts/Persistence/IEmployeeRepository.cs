using HRManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Contracts.Persistence
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        Task<(IReadOnlyList<Employee> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);
    }
}
