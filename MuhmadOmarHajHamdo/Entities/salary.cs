using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MuhmadOmarHajHamdo.Entities;

public partial class salary
{
    [Key] public int Id { get; set; }

    public double Mount { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public int UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("salaries")]
    public virtual employee User { get; set; } = null!;
}