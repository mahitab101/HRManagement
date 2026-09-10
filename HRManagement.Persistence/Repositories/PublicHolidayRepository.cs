using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain.Entities;
using HRManagement.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Persistence.Repositories
{
    public class PublicHolidayRepository : BaseRepository<PublicHoliday>, IPublicHolidayRepository
    {
        public PublicHolidayRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<IReadOnlyList<PublicHoliday>> GetHolidaysInRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbContext.PublicHolidays
                .Where(h => h.Date >= startDate.Date && h.Date <= endDate.Date)
                .ToListAsync();
        }
    }
}