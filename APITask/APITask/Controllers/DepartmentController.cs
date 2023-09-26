using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APITask.Models;
using APITask.DTO;
using APITask.Services;
namespace APITask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        readonly Context context;
        readonly IDepartmentRepo departmentRepo;
        public DepartmentController(Context context)
        {
            this.context = context;
            this.departmentRepo = new DepartmentRepo(context);
        }
        [HttpGet]
        public IActionResult GetAllDepartment()
        {
            return Ok(departmentRepo.GetAll());
        }
        [HttpPost]
        public IActionResult GetByIdDepartment([FromBody] int Id)
        {
            return Ok(departmentRepo.GetById(Id));
        }
    }
}
