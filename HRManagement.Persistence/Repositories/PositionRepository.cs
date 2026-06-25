using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain.Entities;
using HRManagement.Persistence.Data;
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
    }
}
