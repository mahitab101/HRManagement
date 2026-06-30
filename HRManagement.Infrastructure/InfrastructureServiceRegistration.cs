using HRManagement.Application.Contracts.Identity;
using HRManagement.Domain.Identity;
using HRManagement.Infrastructure.Services.Account;
using HRManagement.Infrastructure.Services.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAccountService, AccountService>();
            return services;
        }
    }
}
