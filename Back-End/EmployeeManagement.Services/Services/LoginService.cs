using EmployeeManagement.Repositories.Constants;
using EmployeeManagement.Repositories.Extensions;
using EmployeeManagement.Repositories.Repositories.Interfaces;
using EmployeeManagement.Services.Models;
using EmployeeManagement.Services.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using EmployeeData = EmployeeManagement.DAL.Models.Employee;


namespace EmployeeManagement.Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppSettings _appSettings;
        private readonly IEmployeeRepository _employeeRepository;
        public LoginService(IEmployeeRepository employeeRepository, IOptions<AppSettings> appSettings)
        {
            this._employeeRepository = employeeRepository;
            this._appSettings = appSettings.Value;
        }
        public string Authenticate(string email, string password)
        {
            EmployeeData employeeData = this._employeeRepository.GetEmployees().AsEnumerable().SingleOrDefault(x => x.Email == email && x.Password == password);
            
            if (employeeData == null)
                return null;

            Employee employee = employeeData.Cast<Employee>();

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
                    new Claim(ClaimScope.Role, employee.Role),
                    new Claim(ClaimScope.SupervisorId, employee.SupervisorId.ToString()),
                    new Claim(ClaimScope.Address, employee.Address.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
