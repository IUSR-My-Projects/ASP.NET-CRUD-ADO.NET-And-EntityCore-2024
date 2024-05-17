using System.ComponentModel.DataAnnotations;

namespace MuhmadOmarHajHamdo.Models;

public class Category(int id, string name)
{
    [Key] public int Id { get; set; } = id;

    [Required, MaxLength(100), MinLength(5)]
    public string Name { get; set; } = name;

    public static List<Category> Categories { get; set; } = new List<Category>
    {
        new Category(1, "Muhmad Category"),
        new Category(2, "Omar Category"),
        new Category(3, "Ali Category"),
    };
}