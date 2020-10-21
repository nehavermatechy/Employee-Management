using EmployeeManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeManagement.DAL.Interfaces
{
    public interface IEmployeeManagementContext
    {
        DbSet<Employee> Employees { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class;
    }
}
