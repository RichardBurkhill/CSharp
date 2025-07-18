using Microsoft.Data.Sqlite;
using System.Globalization;

namespace EmployeeModel
{
    public static class EmployeeRepository
    {
        public static List<Employee> GetAllEmployees(string dbPath)
        {
            var employees = new List<Employee>();

            using var connection = new SqliteConnection($"Data Source={dbPath}");
            connection.Open();

            string selectCmd = "SELECT FirstName, LastName, BirthDate, JobTitle, Salary, Email FROM Employees";

            using var command = new SqliteCommand(selectCmd, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string firstName = reader.GetString(0);
                string lastName = reader.GetString(1);
                DateTime birthDate = DateTime.Parse(reader.GetString(2), CultureInfo.InvariantCulture);
                string jobTitle = reader.GetString(3);
                decimal salary = reader.GetDecimal(4);
                string email = reader.GetString(5);

                var employee = new Employee(firstName, lastName, birthDate, jobTitle, salary, email);
                employees.Add(employee);
            }

            return employees;
        }
    }
}
