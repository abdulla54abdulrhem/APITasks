using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [ForeignKey("Department")]
        public int ?DeptId { get; set; }

        [JsonIgnore]
        public virtual Department? Department { get; set; }

                                
    }
}
