using EmployeeManagement.Repositories.Constants;
using EmployeeManagement.Repositories.Repositories.Interfaces;
using EmployeeManagement.Services.Constants;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Services.Models;
using EmployeeManagement.Services.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement.Services.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly AppSettings _appSettings;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAuthenticationProvider _authenticationProvider;
        public EmployeeService(IEmployeeRepository employeeRepository, IOptions<AppSettings> appSettings, IAuthenticationProvider authenticationProvider)
        {
            this._employeeRepository = employeeRepository;
            this._appSettings = appSettings.Value;
            this._authenticationProvider = authenticationProvider;
        }
        public List<Employee> GetEmployees()
        {
         return this._employeeRepository.GetEmployees().Select(x => 
         new Employee(x.Id,
                     x.Name,
                     x.Designation,
                     x.Email,
                     x.PhoneNumber,
                     x.Role,
                     x.SupervisorId,
                     x.Password,
                     x.Address)).ToList();
        }

        public List<Employee> GetRoleSpecificEmployees()
        {
            if(this._authenticationProvider.IsAgencyAdmin)
            {
                return GetEmployees();
            }
                return GetSupervisorSpecificEmployees(this._authenticationProvider.EmployeeId);
        }

        private List<Employee> GetSupervisorSpecificEmployees(string employeeId)
        {
            return this.GetEmployees().Where(x => x.SupervisorId.ToString() == employeeId).ToList();
        }

        public string Authenticate(string email, string password)
        {
            var employee = this.GetEmployees().SingleOrDefault(x => x.Email== email && x.Password == password);

            if (employee == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimScope.EmployeeId, employee.Id.ToString()),
                    new Claim(ClaimScope.Name, employee.Name),
                    new Claim(ClaimScope.Designation, employee.Designation),
                    new Claim(ClaimScope.Email, employee.Email),
                    new Claim(ClaimScope.PhoneNumber, employee.PhoneNumber.ToString()),
                    new Claim(ClaimTypes.Role, employee.Role),
                    new Claim(ClaimScope.SupervisorId, employee.SupervisorId.ToString()),
                    new Claim(ClaimScope.Address, employee.Address.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
