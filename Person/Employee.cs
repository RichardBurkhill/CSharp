using System;
using Microsoft.Data.Sqlite;

namespace EmployeeModel
{
    // Derived class with method overriding
    public class Employee : Person
    {
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }

        // Constructor chaining to base class
        public Employee(string firstName, string lastName, DateTime birthDate, string jobTitle, decimal salary, string email)
            : base(firstName, lastName, birthDate, email)
        {
            JobTitle = jobTitle;
            Salary = salary;
        }

        // Save to SQLite database
        public void SaveToDatabase(string dbPath)
        {
            using var connection = new SqliteConnection($"Data Source={dbPath}");
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                    INSERT INTO Employees (FirstName, LastName, BirthDate, JobTitle, Salary, Email)
                    VALUES ($firstName, $lastName, $birthDate, $jobTitle, $salary, $email);
                ";

            command.Parameters.AddWithValue("$firstName", FirstName ?? string.Empty);
            command.Parameters.AddWithValue("$lastName", LastName ?? string.Empty);
            command.Parameters.AddWithValue("$birthDate", BirthDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("$jobTitle", JobTitle ?? string.Empty);
            command.Parameters.AddWithValue("$salary", Salary);
            command.Parameters.AddWithValue("$email", EmailAddress ?? string.Empty);

            command.ExecuteNonQuery();
        }

        // Method override
        public override string Greet() =>
            $"{base.Greet()} I work as a {JobTitle} and earn {Salary:C}.";

        // Calculate National Insurance contributions
        public (decimal employeeNi, decimal employerNi) CalculateNationalInsurance()
        {
            return EmployeeModel.NICalculator.Calculate(Salary);
        }
        // Calculate tax
        public decimal CalculateTax()
        {
            return EmployeeModel.IncomeTaxCalculator.CalculateIncomeTax(Salary);
        }
    }
}