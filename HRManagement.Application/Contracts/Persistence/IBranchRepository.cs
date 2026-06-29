using HRManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Contracts.Persistence
{
    public interface IBranchRepository : IBaseRepository<Branch>
    {
        Task<IReadOnlyList<Branch>> GetAllWithEmployeesAsync();
        Task<Branch> GetByIdWithDetailsAsync(Guid id);
    }
}
