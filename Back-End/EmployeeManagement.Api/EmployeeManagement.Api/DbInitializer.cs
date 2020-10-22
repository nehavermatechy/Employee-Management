using EmployeeManagement.DAL;
using EmployeeManagement.Api.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EmployeeManagement.Api
{
    public static class DbInitializer
    {
        public static void SeedData(IServiceProvider services)
        {
            using (var context = services.GetService<EmployeeManagementContext>())
            {
                if (!context.Employees.Any())
                {
                    AddEmployeeData(context);
                    CreateStoredProcedures(services);
                }
                context.SaveChanges();
            }
        }

        private static void CreateStoredProcedures(IServiceProvider services)
        {
            services.GetRequiredService<EmployeeManagementContext>().Database.ExecuteSqlRaw(CommonConfig.GET_ALL_EMPLOYEES_SP);
        }

        private static void AddEmployeeData(EmployeeManagementContext context)
        {
            context.Employees.AddRange(CommonConfig.Employees);
        }
    }
}
