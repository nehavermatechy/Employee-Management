using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.DAL.Abstract
{
    public abstract class EmployeeManagementEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
    }
}
