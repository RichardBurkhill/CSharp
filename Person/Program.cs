using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

// Record type (immutable data holder introduced in C# 9.0)
public record TaskItem(string Description, bool IsCompleted);

public class Program
{
    public static void Main()
    {
        string dbPath = "CoronationStreet.db";

        // 1. Create DB & table if needed
        Database.DatabaseInitialiser.InitializeDatabase(dbPath);

        // 3. Read all employees
        var employees = EmployeeModel.EmployeeRepository.GetAllEmployees(dbPath);

        // 4. Greet
        foreach (var emp in employees)
        {
            Console.WriteLine(emp.Greet());
        }

        var RichardBurkhill = new EmployeeModel.Employee("Richard", "Burkhill", new DateTime(1977, 11, 5), "Software Engineer", 53000m, "RichardBurkhill4@gmail.com");
        var LizMcDonald = new EmployeeModel.Employee("Liz", "McDonald", new DateTime(1963, 6, 15), "Bar Manager", 30000m, "Liz@CoronationStreet.co.uk");
        var SteveMcDonald = new EmployeeModel.Employee("Steve", "McDonald", new DateTime(1975, 3, 20), "Owner Street Cars, Owner Rovers Return", 80000m, "Steve@CoronationStreet.co.uk");
        var DannyBaldwin = new EmployeeModel.Employee("Danny", "Baldwin", new DateTime(1970, 1, 1), "Owner Underworld", 100_000m, "Danny@CoronationStreet.co.uk");
        var FrankieBaldwin = new EmployeeModel.Employee("Frankie", "Baldwin", new DateTime(1970, 5, 10), "Waitress Roy's Rolls", 12000m, "Frankie@CoronationStreet.co.uk");
        var VeraDuckworth = new EmployeeModel.Employee("Vera", "Duckworth", new DateTime(1940, 2, 20), "Waitress Roy's Rolls", 14000m, "Vera@CoronationStreet.co.uk");
        var employeeList = new List<EmployeeModel.Employee> { RichardBurkhill, LizMcDonald, SteveMcDonald, DannyBaldwin, FrankieBaldwin, VeraDuckworth };

        //Write out employees to SQLite database
        foreach (var emp in employeeList)
        {
            emp.SaveToDatabase(dbPath);
        }
        // 5. National Insurance Calculation

            // Static method usage
        var anon = Person.CreateAnonymous();
            Console.WriteLine(anon.Greet());

            // LINQ example: list of records
            var tasks = new List<TaskItem>
        {
            new("Learn C#", false),
            new("Build a project", true),
            new("Take a break", true)
        };

            var completedTasks = tasks.Where(t => t.IsCompleted)
                                      .Select(t => t.Description);

            Console.WriteLine("Completed tasks:");
            foreach (var task in completedTasks)
            {
                Console.WriteLine($" - {task}");
            }

            DataStructuresBenchmark.RunBenchmarks();
            LowLevelProgramming.RunDemonstration();
        }
    }
