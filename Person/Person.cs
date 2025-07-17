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
    public string? EmailAddress { get; set; } // Nullable reference type for email address

    // Read-only property with a backing field
    private readonly DateTime _birthDate;
    public DateTime BirthDate => _birthDate;

    private string ForEquals => (BirthDate.Year.ToString() + ' ' + BirthDate.Month.ToString() + ' ' + BirthDate.Day.ToString() + ' ' + FirstName + ' ' + LastName );

    // Computed property (expression-bodied member)
    public int Age => DateTime.Today.Year - BirthDate.Year -
                      (DateTime.Today < BirthDate.AddYears(DateTime.Today.Year - BirthDate.Year) ? 1 : 0);

    public override bool Equals(object? obj) => obj is Person other && (ForEquals) == other.ForEquals;
    public bool Equals(Person? other) => other is not null && ForEquals == other.ForEquals;
    public override int GetHashCode() => ForEquals.GetHashCode();

    // Constructor
    public Person(string firstName, string lastName, DateTime birthDate, string emailAddress)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        _birthDate = birthDate;
    }

    // Method (instance)
    public virtual string Greet() =>
        $"Hello, I'm {FirstName} {LastName} and I'm {Age} years old.";

    // Static method
    public static Person CreateAnonymous() =>
        new Person("John", "Doe", new DateTime(1990, 1, 1), "john.doe@example.com");
}