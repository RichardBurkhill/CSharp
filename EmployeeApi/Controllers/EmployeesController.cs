using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using EmployeeApi.Services;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{email}")]
        public ActionResult<Employee> Get(string email)
        {
            var employee = _employeeService.GetByEmail(email);
            return employee is not null ? Ok(employee) : NotFound();
        }

        [HttpPost]
        public ActionResult<Employee> Post(Employee employee)
        {
            var created = _employeeService.Add(employee);
            return CreatedAtAction(nameof(Get), new { email = created.Email }, created);
        }
    }
}
