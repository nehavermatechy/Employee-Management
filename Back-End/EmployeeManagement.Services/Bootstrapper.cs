using EmployeeManagement.DAL;
using EmployeeManagement.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EmployeeManagement.Domain
{
    public static class Bootstrapper
    {
        public static void ApplyEFMigrations(IServiceScope scope)
        {
            scope.ServiceProvider.GetRequiredService<EmployeeManagementContext>().Database.EnsureCreated();
        }

        public static AppSettings GetAppSettings(IConfiguration configuration)
        {
            IConfigurationSection appSettingsSection = configuration.GetSection("EmployeeConfig");
            var appSettings = appSettingsSection.Get<AppSettings>();
            return appSettings;
        }
    }
}
