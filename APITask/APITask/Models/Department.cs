using System.ComponentModel.DataAnnotations;

namespace APITask.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string ?Name { get; set; }
        public virtual List<Employee> Employees { get; set; }

    }
}
