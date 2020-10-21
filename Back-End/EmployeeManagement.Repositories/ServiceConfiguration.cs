using EmployeeManagement.DAL;
using EmployeeManagement.DAL.Interfaces;
using EmployeeManagement.Repositories.Repositories;
using EmployeeManagement.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceConfiguration
    {
        public static void AddDAL(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<EmployeeManagementContext>(options);

            services.AddScoped<IEmployeeManagementContext, EmployeeManagementContext>();
            
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
