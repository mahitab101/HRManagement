using HRManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRManagement.Application.Contracts.Persistence
{
    public interface IPublicHolidayRepository : IBaseRepository<PublicHoliday>
    {
        Task<IReadOnlyList<PublicHoliday>> GetHolidaysInRangeAsync(DateTime startDate, DateTime endDate);
    }
}