namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        private readonly List<EmployeeModel.Employee> _employees = new();

        public List<EmployeeModel.Employee> GetAll() => _employees;

        public EmployeeModel.Employee? GetByEmail(string email) => _employees.FirstOrDefault(e => e.Email == email);

        public EmployeeModel.Employee Add(EmployeeModel.Employee emp)
        {
            _employees.Add(emp);
            return emp;
        }
    }
}
