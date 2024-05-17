using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MuhmadOmarHajHamdo.Entities;

[Index("Name", Name = "UQ__employee__737584F665429F01", IsUnique = true)]
[Index("PhoneNumber", Name = "UQ__employee__85FB4E3895EBB785", IsUnique = true)]
public partial class employee
{
    [Key] public int Id { get; set; }

    [StringLength(100)] [Unicode(false)] public string Name { get; set; } = null!;

    [StringLength(100)] [Unicode(false)] public string BirthYear { get; set; } = null!;

    [StringLength(20)] [Unicode(false)] public string? PhoneNumber { get; set; }

    [InverseProperty("User")] public virtual ICollection<salary> salaries { get; set; } = new List<salary>();
}