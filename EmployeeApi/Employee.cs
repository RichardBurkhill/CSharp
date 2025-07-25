using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Models
{
    public class Employee
    {
        public int Id { get; set; }  // EF Core primary key
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email length can't be more than 100 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(50, ErrorMessage = "Job title length can't be more than 50 characters.")]
        [RegularExpression(@"^[A-Z][a-z]+(?:\s[A-Z][a-z]+)*$", ErrorMessage = "Job title must start with a capital letter and contain only letters and spaces.")]
        public string JobTitle { get; set; } = string.Empty;
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Salary must be a valid decimal number with up to two decimal places.")]
        public decimal Salary { get; set; }
    }
}
