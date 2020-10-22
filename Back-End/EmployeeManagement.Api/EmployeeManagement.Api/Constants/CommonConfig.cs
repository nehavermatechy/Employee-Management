using EmployeeManagement.DAL.Models;
using EmployeeManagement.Services.Constants;
using System.Collections.Generic;

namespace EmployeeManagement.Api.Constants
{
    public static class CommonConfig
    {
       public const string GET_ALL_EMPLOYEES_SP = "CREATE PROCEDURE GetAllEmployee AS BEGIN SELECT [Id], [Name], [Designation], [Email], [PhoneNumber], [Role], [SupervisorId], [Address], [Password] FROM Employees END";

       public readonly static List<Employee> Employees = new List<Employee>
       {
         new Employee(1,"Super Admin", "Administrator", "admin@mailinator.com", 12345567, RoleConfig.Admin, 0,  "Hosting@123", "Los Angeles, CA"),
         new Employee(2,"Steve Henry", "Junior Software Developer", "steve@mailinator.com", 343242334, RoleConfig.Employee, 9,  "steve@123", "Los Angeles, CA"),
         new Employee(3,"Tony Hilton", "Senior Software Developer", "tony@mailinator.com", 343242334, RoleConfig.Employee, 8,  "tony@123", "Los Angeles, CA"),
         new Employee(4,"Alex", "Junior Software Tester", "alex@mailinator.com", 343242345, RoleConfig.Employee, 7,  "alex@123", "Los Angeles, CA"),
         new Employee(5,"John Barley", "Junior Software Developer", "john@mailinator.com", 343242356, RoleConfig.Employee, 6,  "john@123", "Los Angeles, CA"),
         new Employee(6,"Emma Joson", "Junior Software Developer", "emma@mailinator.com", 343242378, RoleConfig.Employee, 5,  "emma@123", "Los Angeles, CA"),
         new Employee(7,"Jhonathan Cruze", "Senior Software Tester", "jhonathan@mailinator.com", 343242390, RoleConfig.Employee, 5,  "jhonathan@123", "Los Angeles, CA"),
         new Employee(8,"Emily Stiff", "Senior Software Developer", "emily@mailinator.com", 343242365, RoleConfig.Employee, 5,  "emily@123", "Los Angeles, CA"),
         new Employee(9,"Stiffen Henry", "Junior Software Developer", "stiffen@mailinator.com", 343242354, RoleConfig.Employee, 5,  "stiffen@123", "Los Angeles, CA"),
         new Employee(10,"Charles Babbage", "Senior Software Developer", "charles@mailinator.com", 343242343, RoleConfig.Employee, 5,  "charles@123", "Los Angeles, CA"),
         new Employee(11,"Charlie John", "Junior Software Developer", "charlie@mailinator.com", 343242332, RoleConfig.Employee, 5,  "charlie@123", "Los Angeles, CA"),
                      
         new Employee(12,"Dan Watson", "Senior Software Tester", "dan@mailinator.com", 343242321, RoleConfig.Employee, 2, "dan@123", "Los Angeles, CA"),
         new Employee(13,"Tom Hillry", "Junior Software Developer", "tom@mailinator.com", 343242331, RoleConfig.Employee, 2, "tom@123", "Los Angeles, CA"),
         new Employee(14,"John Baptise", "Senior Software Developer", "john2@mailinator.com", 343242325, RoleConfig.Employee, 2, "john1@123", "Los Angeles, CA"),
         new Employee(15,"Samuel Miller", "Junior Software Developer", "samuel@mailinator.com", 343242353, RoleConfig.Employee, 2, "samuel@123", "Los Angeles, CA"),
         new Employee(16,"Steffen Rex", "Senior Software Tester", "steffen@mailinator.com", 343242383, RoleConfig.Employee, 2, "steffen@123", "Los Angeles, CA"),
         new Employee(17,"Henrylle Miller", "Junior Software Developer", "henry@mailinator.com", 343242393, RoleConfig.Employee, 2, "henry@123", "Los Angeles, CA"),
         new Employee(18,"Milton Desouza", "Senior Software Developer", "milton@mailinator.com", 343242343, RoleConfig.Employee, 2, "milton@123", "Los Angeles, CA"),
         new Employee(19,"Mark Henry", "Junior Software Tester", "mark@mailinator.com", 343242363, RoleConfig.Employee, 2, "mark@123", "Los Angeles, CA"),
         new Employee(20,"Henryne Enqiq", "Junior Software Developer", "henry3@mailinator.com", 343242433, RoleConfig.Employee, 2, "henry@123", "Los Angeles, CA"),
         new Employee(21,"Megan Desouza", "Junior Software Tester", "megan@mailinator.com", 343262333, RoleConfig.Employee, 2, "megan@123", "Los Angeles, CA"),
         new Employee(22,"Carl Johnson", "Junior Software Developer", "carl@mailinator.com", 343342333, RoleConfig.Employee, 2, "carl@123", "Los Angeles, CA"),
                      
         new Employee(23,"Daniel Watson", "Senior Software Tester", "dan1@mailinator.com", 343242321, RoleConfig.Employee, 3, "dan3@123", "Los Angeles, CA"),
         new Employee(24,"Tom Hillry", "Junior Software Developer", "tom1@mailinator.com", 343242331, RoleConfig.Employee, 3, "tom3@123", "Los Angeles, CA"),
         new Employee(25,"John Baptise", "Senior Software Developer", "john1@mailinator.com", 343242325, RoleConfig.Employee, 3, "john3@123", "Los Angeles, CA"),
         new Employee(26,"Samuel Miller", "Junior Software Developer", "samuel1@mailinator.com", 343242353, RoleConfig.Employee, 3, "samuel3@123", "Los Angeles, CA"),
         new Employee(27,"Steffen Rex", "Senior Software Tester", "steffen1@mailinator.com", 343242383, RoleConfig.Employee, 3, "steffen3@123", "Los Angeles, CA"),
         new Employee(28,"Henry Miller", "Junior Software Developer", "henry1@mailinator.com", 343242393, RoleConfig.Employee, 3, "henry3@123", "Los Angeles, CA"),
         new Employee(29,"Dannie Desouza", "Senior Software Developer", "milton1@mailinator.com", 343242343, RoleConfig.Employee, 3, "milton3@123", "Los Angeles, CA"),

                     
         new Employee(34,"Dany Watson", "Senior Software Tester", "dan2@mailinator.com", 343242321, RoleConfig.Employee, 4, "dan4@123", "Los Angeles, CA"),
         new Employee(35,"Tomy Hillry", "Junior Software Developer", "tom2@mailinator.com", 343242331, RoleConfig.Employee, 4, "tom4@123", "Los Angeles, CA"),
                      
         new Employee(36,"Henrylap Enqiq", "Junior Software Developer", "henry2@mailinator.com", 343242433, RoleConfig.Employee, 4, "henry4@123", "Los Angeles, CA"),
         new Employee(37,"Meganaca Desouza", "Junior Software Tester", "megan2@mailinator.com", 343262333, RoleConfig.Employee, 4, "megan4@123", "Los Angeles, CA"),
         new Employee(38,"Carie Johnson", "Junior Software Developer", "carl2@mailinator.com", 343342333, RoleConfig.Employee, 4, "carl4@123", "Los Angeles, CA"),

       };
    }
}
