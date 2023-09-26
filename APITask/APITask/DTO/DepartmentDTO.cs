namespace APITask.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Employees { get; set; } = new List<string>();
    }
}
