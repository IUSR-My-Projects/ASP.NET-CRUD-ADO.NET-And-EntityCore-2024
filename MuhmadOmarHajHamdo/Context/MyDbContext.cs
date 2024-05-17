using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MuhmadOmarHajHamdo.Entities;

namespace MuhmadOmarHajHamdo.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<employee> employees { get; set; }

    public virtual DbSet<salary> salaries { get; set; }

    public virtual DbSet<test> tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(
            "Server=localhost;Database=MuhmadOmar;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<employee>(entity => { entity.HasKey(e => e.Id).HasName("Id"); });

        modelBuilder.Entity<salary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__salaries__3214EC072BCA6AD6");

            entity.HasOne(d => d.User).WithMany(p => p.salaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employeeId__fk");
        });

        modelBuilder.Entity<test>(entity =>
        {
            entity.HasKey(e => e.column_name).HasName("tests_pk");

            entity.Property(e => e.column_name).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}