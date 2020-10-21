using EmployeeManagement.DAL.Interfaces;
using EmployeeManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeManagement.DAL
{
    public class EmployeeManagementContext : DbContext, IEmployeeManagementContext
    {
        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class => this.Set<TEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees");
            base.OnModelCreating(modelBuilder);
        }


    }
}
