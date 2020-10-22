using EmployeeManagement.Repositories.Constants;
using EmployeeManagement.Services.Constants;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace EmployeeManagement.Services.Providers
{
  
        public class AuthenticationProvider : IAuthenticationProvider
        {
        private readonly IHttpContextAccessor contextAccessor;

        public AuthenticationProvider(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public string EmployeeId =>this.GetClaim(ClaimScope.EmployeeId);

        public bool IsAgencyAdmin => this.IsAdmin();

        private string GetClaim(string claimType) 
        {
            if (this.contextAccessor.HttpContext.User.Claims.Any())
            {
                return this.contextAccessor.HttpContext.User.Claims.First(c => c.Type.Equals(claimType, StringComparison.OrdinalIgnoreCase)).Value;
            }

            return string.Empty;
        }

        private bool IsAdmin()
        {
            var userRole = this.GetClaim(ClaimTypes.Role);
            return userRole != null && userRole == RoleConfig.Admin;
        }
    }
    
}
