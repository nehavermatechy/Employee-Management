using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Services.Services.Interfaces
{
    public interface ILoginService
    {
        string Authenticate(string email, string password);
    }
}
