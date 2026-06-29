using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain.Entities;
using HRManagement.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Persistence.Repositories
{
    public class PositionRepository:BaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IReadOnlyList<Position>> GetAllWithDepartmentAsync()
        {
            return await _dbContext.Positions
                .Include(p => p.Department)
                .ToListAsync();
        }
    }
}
