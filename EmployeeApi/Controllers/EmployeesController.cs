using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using EmployeeApi.Services;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        //To build this controller, you need to give me an EmployeeService.
        // I don't care how you get it, just give me one.
        // This is called dependency injection.
        // The DI container will provide an instance of EmployeeService when it creates an instance of EmployeesController.
        // The constructor takes an EmployeeService parameter,
        // which is automatically provided by the ASP.NET Core dependency injection system.
        // This way, you can use the EmployeeService methods to handle requests.
        // This is a common pattern in ASP.NET Core to keep controllers clean and focused on handling
        // HTTP requests rather than managing dependencies directly.
        // And the DI container resolves that dependency automatically at runtime.
        private readonly EmployeeService _employeeService;
        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // HTTP GET api/employees
        [HttpGet("{email}")]
        public ActionResult<Employee> Get(string email)
        {
            var employee = _employeeService.GetByEmail(email);
            return employee is not null ? Ok(employee) : NotFound();
        }

        // HTTP POST api/employees
        // This endpoint allows you to create a new employee.
        // It expects an Employee object in the request body.
        // If the employee is successfully created, it returns a 201 Created response
        // with the created employee's details.
        // The CreatedAtAction method generates a response that includes the URI of the newly created resource
        // (in this case, the employee) based on the Get method.
        // This is useful for clients to know how to retrieve the newly created employee.
        // If the employee already exists, it will return a 400 Bad Request response.
        // This is a common pattern in REST APIs to provide a clear and consistent way to create
        // new resources and inform clients about the result of their request.
        // The [HttpPost] attribute indicates that this method handles HTTP POST requests.
        // The ActionResult<Employee> return type allows you to return different HTTP status codes
        // and the Employee object when successful.
        // The Employee parameter is automatically bound from the request body.
        // ASP.NET Core will validate the model and return a 400 Bad Request response if the model is invalid.
        // The CreatedAtAction method generates a response that includes the URI of the newly created resource
        // (in this case, the employee) based on the Get method.
        // This is useful for clients to know how to retrieve the newly created employee.
        // The CreatedAtAction method takes the name of the action (Get) and the route values (email) to generate the URI.
        // The CreatedAtAction method also takes the created employee object as the third parameter to include it in the response body.
        [HttpPost]
        public ActionResult<Employee> Post(Employee employee)
        {
            var created = _employeeService.Add(employee);
            return CreatedAtAction(nameof(Get), new { email = created.Email }, created);
        }
    }
}
