
namespace EmployeeManagement.Services.Interfaces
{
    public interface IAuthenticationProvider
    {
        string EmployeeId { get;}

        bool IsAgencyAdmin { get; }
    }
}
