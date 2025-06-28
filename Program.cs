using System;
using System.Collections.Generic;
using System.Linq;

// Interface declaration
public interface IGreetable
{
    string Greet();
}

// Base class
public class Person : IGreetable
{
    // Auto-implemented property with nullable reference type
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    // Read-only property with a backing field
    private readonly DateTime _birthDate;
    public DateTime BirthDate => _birthDate;

    // Computed property (expression-bodied member)
    public int Age => DateTime.Now.Year - _birthDate.Year;

    // Constructor
    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        _birthDate = birthDate;
    }

    // Method (instance)
    public virtual string Greet() =>
        $"Hello, I'm {FirstName} {LastName} and I'm {Age} years old.";

    // Static method
    public static Person CreateAnonymous() =>
        new Person("John", "Doe", new DateTime(1990, 1, 1));
}

// Derived class with method overriding
public class Employee : Person
{
    public string JobTitle { get; set; }
    public decimal Salary { get; set; }

    // Constructor chaining to base class
    public Employee(string firstName, string lastName, DateTime birthDate, string jobTitle, decimal salary)
        : base(firstName, lastName, birthDate)
    {
        JobTitle = jobTitle;
        Salary = salary;
    }

    // Method override
    public override string Greet() =>
        $"{base.Greet()} I work as a {JobTitle} and earn {Salary:C}.";
}

// Record type (immutable data holder introduced in C# 9.0)
public record TaskItem(string Description, bool IsCompleted);

public class Program
{
    public static void Main()
    {
        var employee = new Employee("Alice", "Smith", new DateTime(1992, 4, 10), "Software Engineer", 53000m);
        Console.WriteLine(employee.Greet());

        // Static method usage
        var anon = Person.CreateAnonymous();
        Console.WriteLine(anon.Greet());

        // LINQ example: list of records
        var tasks = new List<TaskItem>
        {
            new("Learn C#", true),
            new("Build a project", false),
            new("Take a break", true)
        };

        var completedTasks = tasks.Where(t => t.IsCompleted)
                                  .Select(t => t.Description);

        Console.WriteLine("✅ Completed tasks:");
        foreach (var task in completedTasks)
        {
            Console.WriteLine($" - {task}");
        }
    }
}
