using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuhmadOmarHajHamdo.Models;

public class Salary(float mount, int month, int year, Employee employee)
{
    [Key] public int Id { get; set; }
    public float Mount { get; set; } = mount;
    public int Month { get; set; } = month;
    public int Year { get; set; } = year;

    [ForeignKey("UserId")] public Employee Employee { get; set; } = employee;
}