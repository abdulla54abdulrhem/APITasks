using Microsoft.EntityFrameworkCore;

namespace APITask.Models
{
    public class Context : DbContext
    {
        public Context()
        {
            
        }
        public Context(DbContextOptions options) : base(options)
        {
            //inorder to inject the options
        }
        public DbSet<Employee>Employees { get; set; }
    }
}
