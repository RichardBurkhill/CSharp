using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using EmployeeApi.Services;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private static readonly List<Employee> _employees = new();

        [HttpGet("{email}")]
        public ActionResult<Employee> Get(string email)
        {
            var employee = _employees.FirstOrDefault(e => e.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return employee is not null ? Ok(employee) : NotFound();
        }

        [HttpPost]
        public ActionResult<Employee> Post(Employee employee)
        {
            _employees.Add(employee);
            return CreatedAtAction(nameof(Get), new { email = employee.Email }, employee);
        }
    }
}
