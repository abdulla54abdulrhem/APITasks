using APITask.DTO;
using APITask.Models;
using Microsoft.EntityFrameworkCore;

namespace APITask.Services
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private Context _context;
        public DepartmentRepo(Context context)
        {
            _context = context;
        }
        public void DeleteById(int Id)
        {
            Department department = _context.Departments.FirstOrDefault(x => x.Id == Id);
            if (department == null)
                return;
            _context.Departments.Remove(department);
        }

        public List<DepartmentDTO> GetAll()
        {
            List<DepartmentDTO>depts = new List<DepartmentDTO>();
            List<Department>departments = _context.Departments
                .Include(x=>x.Employees)
                .ToList();
            foreach (var it in departments)
            {
                depts.Add(CreateDeptDTO(it));
            }
            return depts;
        }

        public DepartmentDTO GetById(int Id)
        {
           Department department = _context.Departments.Include(x=>x.Employees).FirstOrDefault(x => x.Id == Id);
            if (department == null)
                return null;
            return CreateDeptDTO(department);

        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public DepartmentDTO CreateDeptDTO(Department d)
        {
            DepartmentDTO dTO = new DepartmentDTO();
            dTO.Id = d.Id;
            dTO.Name = d.Name;
            foreach (var it in d.Employees)
            {
                dTO.Employees.Add(it.Name);
            }
            return dTO;
        }
    }
}
