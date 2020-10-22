using EmployeeManagement.DAL.Abstract;

namespace EmployeeManagement.Services.Models
{
    public class Employee
    {
        public Employee()
        {

        }
        public Employee(int employeeId, string name, string designation, string email, int phoneNumber, string role, int supervisorId,  string password, string address)
        {
            this.Id = employeeId;
            this.Name = name;
            this.Designation = designation;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Role = role;
            this.SupervisorId = supervisorId;
            this.Password = password;
            this.Address = address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Designation { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public string Role { get; set; }

        public int SupervisorId { get; set; }


        public string Password { get; set; }

        public string Address { get; set; }

        public string Token { get; set; }
    }
}
