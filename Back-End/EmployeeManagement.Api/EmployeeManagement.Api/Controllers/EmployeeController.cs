using System;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILoginService _loginService;

        public EmployeeController(IEmployeeService employeeService, ILoginService _loginService, IHttpContextAccessor contextAccessor)
        {
            this._employeeService = employeeService;
            this._loginService = _loginService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ApiStarted()
        {
                return this.Ok("Web API running!");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Login")]
        public IActionResult Login(string email, string password)
        {
            try
            {
                var employeeToken = this._loginService.Authenticate(email, password);
                return this.Ok(employeeToken);
            }
            catch(Exception ex)
            {
              return this.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult GetEmployees()
        {
            try
            {
                var employees = this._employeeService.GetRoleSpecificEmployees();
                return this.Ok(employees);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.Message);
            }

        }
    }
}
