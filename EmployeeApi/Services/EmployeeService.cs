using System.Numerics;
using EmployeeApi.Data;
using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Services
{
    public record EmployeePaySlip
    {
        public Employee? Employee { get; init; }
        public decimal GrossPay { get; init; }
        public decimal EmployeeNI { get; init; }
        public decimal EmployerNI { get; init; }
        public decimal NetPay { get; init; }
    }
    public class EmployeeService
    {
        private readonly EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetByEmailAsync(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Employee> AddAsync(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task<decimal> CalculateYearlyWageBillAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            // Calculate yearly wage bill
            decimal total = 0;
            foreach (var emp in employees)
            {
                total += emp.Salary;
                total += emp.Salary * NICalculator.Calculate(emp.Salary).employerNi;
                total += emp.Salary * (emp.PensionContribution / 100); // Assuming PensionContribution is a percentage
            }
            return total;
        }

        public async Task<List<EmployeePaySlip>> GeneratePaySlipsAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            var paySlips = new List<EmployeePaySlip>();

            foreach (var emp in employees)
            {
                var (employeeNi, employerNi) = NICalculator.Calculate(emp.Salary);
                var netPay = emp.Salary - employeeNi;

                paySlips.Add(new EmployeePaySlip
                {
                    Employee = emp,
                    GrossPay = emp.Salary / 12.0m, // Assuming Salary is annual, convert to monthly
                    EmployeeNI = employeeNi,
                    EmployerNI = employerNi,
                    NetPay = (emp.Salary / 12.0m) - employeeNi - ((emp.PensionContribution / 100) * (emp.Salary / 12.0m)) // Assuming PensionContribution is a percentage
                });
            }

            return paySlips;
        }
    }
}
