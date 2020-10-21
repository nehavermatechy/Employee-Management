using EmployeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagement.Repositories.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetEmployees();
    }
}
