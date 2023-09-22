using System.ComponentModel.DataAnnotations;

namespace APITask.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string ?Name { get; set; }
        [Range(1,20000)]
        public double Salary { get; set; }
        public string ?Address { get; set;}
        [Range(0,int.MaxValue)]
        public int ?Phone { get; set;}
    }
}
