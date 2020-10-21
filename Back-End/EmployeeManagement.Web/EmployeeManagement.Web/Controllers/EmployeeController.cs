using System;
using EmployeeManagement.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILoginService _loginService;

        public EmployeeController(IEmployeeService employeeService, ILoginService _loginService)
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
              return this.Ok();
            }
        }

        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult GetEmployees(string role, string employeeId)
        {
            try
            {
                var employees = this._employeeService.GetRoleSpecificEmployees(role, employeeId);
                return this.Ok(employees);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.Message);
            }

        }
    }
}
