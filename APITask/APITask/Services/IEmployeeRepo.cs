using APITask.Models;
namespace APITask.Services
{
    public interface IEmployeeRepo
    {
        public List<Employee> GetAll();
        public Employee GetById(int id);
        public Employee GetByName(string name);
        public void Add(Employee e);
        public void Update(Employee e);
        public void Delete(int id);
        public void Save();
    }
}
