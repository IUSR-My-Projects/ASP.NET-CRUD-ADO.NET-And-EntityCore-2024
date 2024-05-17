using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;
using MuhmadOmarHajHamdo.Models.Repositories;

namespace MuhmadOmarHajHamdo.Models;

public class Employee(int id, string name, DateTime birthYear, string phoneNumber)
{
    [Key, IntegerValidator] public int Id { get; set; } = id;

    [NotNull, Required(ErrorMessage = "هذا الحقل مطلوب"), MaxLength(100, ErrorMessage = "أقصى حد 100 حرف")]
    public string Name { get; set; } = name;

    [NotNull, Required(ErrorMessage = "هذا الحقل مطلوب")]
    public DateTime BirthYear { get; set; } = birthYear;

    [MaxLength(20, ErrorMessage = "أقصى حد 20"), UniquePhoneNumber]
    public string PhoneNumber { get; set; } = phoneNumber;

    public List<Salary> Salaries { get; set; } = new List<Salary>();
}

public class UniquePhoneNumberAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string phoneNumber = (string)value;

        bool isUnique = new EmployeeRepository().CheckUniquePhoneNumber(phoneNumber);

        if (!isUnique)
        {
            return new ValidationResult("Phone number must be unique.");
        }

        return ValidationResult.Success;
    }
}