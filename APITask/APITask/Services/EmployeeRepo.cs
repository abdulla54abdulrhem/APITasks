using APITask.Models;

namespace APITask.Services
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly Context _context;
        public EmployeeRepo(Context context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(x=>x.Id == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }

        public Employee GetByName(string name)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.Name == name);
            return employee;
        }

        public void Add(Employee e)
        {
            _context.Employees.Add(e);
        }

        public void Update(Employee e)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.Id == e.Id);
            if (employee == null) return;
            employee.Name = e.Name;
            employee.Salary = e.Salary;
            employee.Address = e.Address;
            employee.Phone = e.Phone;
           
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
