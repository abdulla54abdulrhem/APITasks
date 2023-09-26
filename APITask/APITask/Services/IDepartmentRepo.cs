using APITask.DTO;
namespace APITask.Services
{
    public interface IDepartmentRepo
    {
        public List<DepartmentDTO> GetAll();
        public DepartmentDTO GetById(int Id);
        public void DeleteById(int Id);
        public void Save();
    }
}
