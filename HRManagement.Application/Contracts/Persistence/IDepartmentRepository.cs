using HRManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Contracts.Persistence
{
    public interface IDepartmentRepository:IBaseRepository<Department>
    {
        Task<IReadOnlyList<Department>> GetAllWithEmployeesAsync();
    }
}
