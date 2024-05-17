using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MuhmadOmarHajHamdo.Entities;

public partial class test
{
    [Key] public int column_name { get; set; }
}