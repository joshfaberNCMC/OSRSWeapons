using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OSRSWeapons.Models;

namespace OSRSWeapons.Repositories;

public partial class OSRSWeaponsDbContext : DbContext
{
    public OSRSWeaponsDbContext()
    {
    }

    public OSRSWeaponsDbContext(DbContextOptions<OSRSWeaponsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Weapon> Weapons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=OSRSWeapons;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Weapon>(entity =>
        {
            entity.Property(e => e.WeaponId).HasColumnName("WeaponID");
            entity.Property(e => e.AttackSpeed).HasDefaultValue(4);
            entity.Property(e => e.Examine).HasMaxLength(255);
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.Modifiable).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PrimaryAttackType).HasMaxLength(10);
            entity.Property(e => e.RequiredAttackLvl).HasDefaultValue(1);
            entity.Property(e => e.RequiredStrengthLvl).HasDefaultValue(1);
            entity.Property(e => e.SecondaryAttackType).HasMaxLength(10);
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 3)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
