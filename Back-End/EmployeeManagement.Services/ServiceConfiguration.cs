using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Services.Models;
using EmployeeManagement.Services.Providers;
using EmployeeManagement.Services.Services;
using EmployeeManagement.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceConfiguration
    {
        public static void AddEmployeeManagementServices(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDAL(options);
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAuthenticationProvider, AuthenticationProvider>();
            services.AddScoped<AppSettings>();
        }
    }
}
