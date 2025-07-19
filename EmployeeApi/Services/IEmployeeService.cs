using EmployeeApi.Models;

namespace EmployeeApi.Services
{
    public interface IEmployeeService
    {
        Task<Employee> AddAsync(Employee emp);
        Task<Employee?> GetByEmailAAsync(string email);
    }
}
