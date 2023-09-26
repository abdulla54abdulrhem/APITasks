using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APITask.Services;
using APITask.Models;
namespace APITask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly Context context;
        readonly IEmployeeRepo employeeRepo;
        public EmployeeController(Context context)
        {
            this.context = context;
            employeeRepo = new EmployeeRepo(context);
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            return Ok(employeeRepo.GetAll());
        }
        [HttpGet("{Id:int}",Name = "GetEmpId")]
        //[Route("{Id:int}")]
        public IActionResult GetByEmployee(int Id)
        {
            Employee employee = employeeRepo.GetById(Id);
            if (employee != null)
                return Ok(employee);
            return NotFound();
        }
        [HttpGet]
        [Route("{Name:alpha}")]
        public IActionResult GetByEmployee(string Name)
        {
            Employee employee = employeeRepo.GetByName(Name);
            if (employee != null)
                return Ok(employee);
            return NotFound();
        }
        [HttpPost]
        public IActionResult PostEmployee(Employee e)
        {
            if (ModelState.IsValid)
            {
                employeeRepo.Add(e);
                employeeRepo.Save();
                string url = Url.Link("GetEmpId", new { Id = e.Id });
                return Created(url, e);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{Id:int}")]
        public IActionResult DeleteEmployee(int Id)
        {
            employeeRepo.Delete(Id);
            employeeRepo.Save();
            return StatusCode(204, "EmployeeDeleted");
        }
    }
}
