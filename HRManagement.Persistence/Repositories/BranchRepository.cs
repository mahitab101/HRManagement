using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain.Entities;
using HRManagement.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Persistence.Repositories
{
    public class BranchRepository:BaseRepository<Branch>,IBranchRepository
    {
        public BranchRepository(AppDbContext dbContext):base(dbContext)
        {
            
        }

        public async Task<IReadOnlyList<Branch>> GetAllWithEmployeesAsync()
        {
            return await _dbContext.Branches.Include(b=>b.Employees).ToListAsync();
        }

        public async Task<Branch> GetByIdWithDetailsAsync(Guid id)
        {
            return await _dbContext.Branches.Include(b => b.Employees).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
