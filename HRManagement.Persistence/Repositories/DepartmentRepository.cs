using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain.Entities;
using HRManagement.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Persistence.Repositories
{
    public class DepartmentRepository:BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IReadOnlyList<Department>> GetAllWithEmployeesAsync()
        {
            return await _dbContext.Departments
                .Include(d => d.Employees)
                .Include(d => d.Manager)
                .ToListAsync();
        }

        public async Task<Department> GetByIdWithDetailsAsync(Guid id)
        {
            return await _dbContext.Departments
                        .Include(d => d.Employees)
                        .Include(d => d.Manager)
                        .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
