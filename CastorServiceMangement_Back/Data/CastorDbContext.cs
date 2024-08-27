using System;
using System.Collections.Generic;
using CastorServiceMangement_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace CastorServiceMangement_Back.Data;

public partial class CastorDbContext : DbContext
{
    public CastorDbContext()
    {
    }

    public CastorDbContext(DbContextOptions<CastorDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__Cargos__6C985625F61BA19C");

            entity.Property(e => e.IdCargo)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empleado__3214EC07687CF7EC");

            entity.Property(e => e.IdCargo)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdCargo)
                .HasConstraintName("FK__Empleados__IdCar__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
