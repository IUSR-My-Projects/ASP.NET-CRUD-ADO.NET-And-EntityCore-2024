namespace MuhmadOmarHajHamdo.Models;

public class User(int id, string name, int age)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
}