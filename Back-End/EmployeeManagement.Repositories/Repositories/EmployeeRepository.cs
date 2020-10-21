using EmployeeManagement.DAL.Interfaces;
using EmployeeManagement.DAL.Models;
using EmployeeManagement.Repositories.Constants;
using EmployeeManagement.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Repositories.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly IEmployeeManagementContext employeeManagementContext;
        public EmployeeRepository(IEmployeeManagementContext employeeManagementContext)
        {
            this.employeeManagementContext = employeeManagementContext;
        }

        public IQueryable<Employee> GetEmployees()
        {
            return this.employeeManagementContext.Set<Employee>().FromSqlRaw(StoredProcedureNames.GetAllEmployee);
        }
    }
}
