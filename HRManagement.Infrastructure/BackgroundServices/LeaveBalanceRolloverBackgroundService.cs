using HRManagement.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Infrastructure.BackgroundServices
{
    public class LeaveBalanceRolloverBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<LeaveBalanceRolloverBackgroundService> _logger;

        public LeaveBalanceRolloverBackgroundService(
            IServiceScopeFactory scopeFactory,
            ILogger<LeaveBalanceRolloverBackgroundService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var leaveBalanceService = scope.ServiceProvider.GetRequiredService<ILeaveBalanceService>();

                    await leaveBalanceService.RunYearlyRolloverAsync(DateTime.UtcNow.Year);

                    _logger.LogInformation("Leave balance rollover check completed for {Year}", DateTime.UtcNow.Year);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Leave balance rollover check failed");
                }

                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}