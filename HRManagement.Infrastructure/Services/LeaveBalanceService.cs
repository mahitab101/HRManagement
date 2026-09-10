using HRManagement.Application.Contracts;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain.Entities;
using HRManagement.Domain.Enums;

namespace HRManagement.Infrastructure.Services
{
    public class LeaveBalanceService : ILeaveBalanceService
    {
        private readonly ILeaveBalanceRepository _leaveBalanceRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public LeaveBalanceService(
            ILeaveBalanceRepository leaveBalanceRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IEmployeeRepository employeeRepository)
        {
            _leaveBalanceRepository = leaveBalanceRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task InitializeBalancesForEmployeeAsync(Guid employeeId, DateTime hireDate)
        {
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();
            var currentYear = DateTime.UtcNow.Year;
            var hireYear = hireDate.Year;

            for (int year = hireYear; year <= currentYear; year++)
            {
                foreach (var leaveType in leaveTypes)
                {
                    var existing = await _leaveBalanceRepository
                        .GetByEmployeeAndLeaveTypeAsync(employeeId, leaveType.Id, year);

                    if (existing == null)
                    {
                        int totalDays;

                        if (year == hireYear)
                        {
                            var endOfHireYear = new DateTime(hireYear, 12, 1);
                            totalDays = CalculateProRataDays(leaveType.MaxDaysPerYear, hireDate, endOfHireYear);
                        }
                        else if (year == currentYear)
                        {
                            var startOfYear = new DateTime(year, 1, 1);
                            totalDays = CalculateProRataDays(leaveType.MaxDaysPerYear, startOfYear, DateTime.UtcNow);
                        }
                        else
                        {
                            totalDays = leaveType.MaxDaysPerYear;
                        }

                        var balance = new LeaveBalance
                        {
                            EmployeeId = employeeId,
                            LeaveTypeId = leaveType.Id,
                            Year = year,
                            TotalDays = totalDays,
                            UsedDays = 0,
                            PendingDays = 0,
                            RemainingDays = totalDays
                        };

                        await _leaveBalanceRepository.AddAsync(balance);
                    }
                }
            }
        }
        public async Task<bool> HasSufficientBalanceAsync(
          Guid employeeId, Guid leaveTypeId, int requestedDays, int year)
        {
            var balance = await _leaveBalanceRepository
                .GetByEmployeeAndLeaveTypeAsync(employeeId, leaveTypeId, year);

            if (balance == null) return false;

            var availableDays = balance.TotalDays - balance.UsedDays - balance.PendingDays;
            return availableDays >= requestedDays;
        }

        public async Task HoldBalanceAsync(Guid employeeId, Guid leaveTypeId, int days, int year)
        {
            var balance = await GetBalanceOrThrowAsync(employeeId, leaveTypeId, year);
            balance.PendingDays += days;
            await _leaveBalanceRepository.UpdateAsync(balance);
        }

        public async Task ReleaseHoldAsync(Guid employeeId, Guid leaveTypeId, int days, int year)
        {
            var balance = await GetBalanceOrThrowAsync(employeeId, leaveTypeId, year);
            balance.PendingDays = Math.Max(0, balance.PendingDays - days);
            await _leaveBalanceRepository.UpdateAsync(balance);
        }

        public async Task ConfirmBalanceAsync(Guid employeeId, Guid leaveTypeId, int days, int year)
        {
            var balance = await GetBalanceOrThrowAsync(employeeId, leaveTypeId, year);
            balance.PendingDays = Math.Max(0, balance.PendingDays - days);
            balance.UsedDays += days;
            balance.RemainingDays = balance.TotalDays - balance.UsedDays;
            await _leaveBalanceRepository.UpdateAsync(balance);
        }

        private async Task<LeaveBalance> GetBalanceOrThrowAsync(Guid employeeId, Guid leaveTypeId, int year)
        {
            var balance = await _leaveBalanceRepository
                .GetByEmployeeAndLeaveTypeAsync(employeeId, leaveTypeId, year);

            if (balance == null)
                throw new InvalidOperationException("Leave balance not found.");

            return balance;
        }

  
        public async Task RestoreBalanceAsync(
            Guid employeeId, Guid leaveTypeId, int days, int year)
        {
            var balance = await _leaveBalanceRepository
                .GetByEmployeeAndLeaveTypeAsync(employeeId, leaveTypeId, year);

            if (balance == null)
                throw new InvalidOperationException("Leave balance not found.");

            balance.UsedDays = Math.Max(0, balance.UsedDays - days);
            balance.RemainingDays = balance.TotalDays - balance.UsedDays;

            await _leaveBalanceRepository.UpdateAsync(balance);
        }


        public async Task RunYearlyRolloverAsync(int year)
        {
            var previousYear = year - 1;

            var employees = await _employeeRepository.GetAllAsync();
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();

            var activeEmployees = employees.Where(e => e.Status != EmployeeStatus.Inactive);

            foreach (var employee in activeEmployees)
            {
                foreach (var leaveType in leaveTypes)
                {
                    // Idempotency: لو الرصيد اتعمل قبل كده لنفس السنة، متعملوش تاني
                    var alreadyExists = await _leaveBalanceRepository
                        .GetByEmployeeAndLeaveTypeAsync(employee.Id, leaveType.Id, year);

                    if (alreadyExists != null)
                        continue;

                    var previousBalance = await _leaveBalanceRepository
                        .GetByEmployeeAndLeaveTypeAsync(employee.Id, leaveType.Id, previousYear);

                    var remainingFromLastYear = Math.Max(0, previousBalance?.RemainingDays ?? 0);

                    var carriedOverDays = 0;
                    if (leaveType.AllowCarryOver)
                    {
                        carriedOverDays = leaveType.MaxCarryOverDays.HasValue
                            ? Math.Min(remainingFromLastYear, leaveType.MaxCarryOverDays.Value)
                            : remainingFromLastYear;
                    }

                    var totalDays = leaveType.MaxDaysPerYear + carriedOverDays;

                    var newBalance = new LeaveBalance
                    {
                        EmployeeId = employee.Id,
                        LeaveTypeId = leaveType.Id,
                        Year = year,
                        TotalDays = totalDays,
                        UsedDays = 0,
                        PendingDays = 0,
                        RemainingDays = totalDays
                    };

                    await _leaveBalanceRepository.AddAsync(newBalance);
                }
            }
        }
        //private int CalculateProRataDays(int maxDaysPerYear, DateTime hireDate)
        //{
        //    var today = DateTime.UtcNow;


        //    if (hireDate.Year < today.Year)
        //        return maxDaysPerYear;

        //    var monthsWorked = today.Month - hireDate.Month + 1;
        //    var proRataDays = (int)Math.Ceiling((double)monthsWorked / 12 * maxDaysPerYear);

        //    return proRataDays;
        //}

        private int CalculateProRataDays(int maxDaysPerYear, DateTime periodStart, DateTime periodEnd)
        {
            var monthsWorked = (periodEnd.Year - periodStart.Year) * 12
                                + (periodEnd.Month - periodStart.Month) + 1;

            monthsWorked = Math.Clamp(monthsWorked, 0, 12);

            return (int)Math.Ceiling((double)monthsWorked / 12 * maxDaysPerYear);
        }
    }
}