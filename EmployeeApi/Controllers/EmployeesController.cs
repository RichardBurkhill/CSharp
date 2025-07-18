using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Services;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeesController(EmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<EmployeeModel.Employee>> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<EmployeeModel.Employee> Get(string email)
        {
            var employee = _service.GetByEmail(email);
            return employee is null ? NotFound() : employee;
        }

        [HttpPost]
        public ActionResult<EmployeeModel.Employee> Create(EmployeeModel.Employee employee)
        {
            var created = _service.Add(employee);
            return CreatedAtAction(nameof(Get), new { email = created.Email }, created);
        }
    }
}
