using HRManagement.Application.Contracts;
using HRManagement.Application.Contracts.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Infrastructure.Services
{
    public class WorkingDaysCalculator : IWorkingDaysCalculator
    {
        private readonly IPublicHolidayRepository _publicHolidayRepository;
        private readonly ISystemSettingService _systemSettingService;
        private readonly IEmployeeRepository _employeeRepository;

        public WorkingDaysCalculator(
            IPublicHolidayRepository publicHolidayRepository,
            ISystemSettingService systemSettingService,
            IEmployeeRepository employeeRepository)
        {
            _publicHolidayRepository = publicHolidayRepository;
            _systemSettingService = systemSettingService;
            _employeeRepository = employeeRepository;
        }

        public async Task<int> CalculateWorkingDaysAsync(Guid employeeId, DateTime startDate, DateTime endDate)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
                throw new InvalidOperationException("Employee not found.");

            var settings = await _systemSettingService.GetSettingsForBranchAsync(employee.BranchId);
            var weekendDays = settings.WeekendDays.ToHashSet();

            var holidays = await _publicHolidayRepository.GetHolidaysInRangeAsync(startDate, endDate);
            var holidayDates = holidays.Select(h => h.Date.Date).ToHashSet();

            var count = 0;
            for (var date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
            {
                if (weekendDays.Contains(date.DayOfWeek)) continue;
                if (holidayDates.Contains(date)) continue;
                count++;
            }

            return count;
        }
    }
}