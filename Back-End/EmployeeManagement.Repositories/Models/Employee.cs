using EmployeeManagement.DAL.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.DAL.Models
{
    [Table("Employees")]
    public class Employee : EmployeeManagementEntity
    {
        public Employee(int id, string name, string designation, string email, int phoneNumber, string role, int supervisorId, string password, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Designation = designation;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Role = role;
            this.SupervisorId = supervisorId;
            this.Password = password;
            this.Address = address;
        }

        [Column("Name")]
        public string Name { get; set; }
        
        [Column("Designation")]
        public string Designation { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("PhoneNumber")]
        public int PhoneNumber { get; set; }

        [Column("Role")]
        public string Role { get; set; }

        [Column("SupervisorId")]
        public int SupervisorId { get; set; }

        [Column("Address")]
        public string Address { get; set; }

        [Column("Password")]
        public string Password { get; set; }
    }
}
