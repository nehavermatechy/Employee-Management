using EmployeeManagement.Services.Models;
using System.Collections.Generic;

namespace EmployeeManagement.Services.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();

        string Authenticate(string email, string password);

        List<Employee> GetRoleSpecificEmployees();
    }
}
