using EmployeeApi.Models;

namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        private readonly List<Employee> _employees = new();

        public Employee? GetByEmail(string email) => _employees.FirstOrDefault(e => e.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        public Employee Add(Employee emp)
        {
            _employees.Add(emp);
            return emp;
        }
    }
}
