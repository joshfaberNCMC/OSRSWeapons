using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OSRSWeapons.Models;

namespace OSRSWeapons.Repositories;

/// <summary>
/// Represents the database context for OSRS weapons
/// </summary>
/// <author>Josh Faber</author>
public partial class OSRSWeaponsDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the OSRSWeaponsDbContext class.
    /// </summary>
    public OSRSWeaponsDbContext()
    {

    }

    /// <summary>
    /// Initializes a new instance of the OSRSWeaponsDbContext class with the specified options
    /// </summary>
    /// <param name="options">The options for configuring the context</param>
    public OSRSWeaponsDbContext(DbContextOptions<OSRSWeaponsDbContext> options) : base(options)
    {

    }

    /// <summary>
    /// Represents the collection of weapons in the database
    /// </summary>
    public virtual DbSet<Weapon> Weapons { get; set; }

    /// <summary>
    /// Configures the database connection for the OSRSWeaponsDbContext
    /// </summary>
    /// <param name="optionsBuilder">The options builder used to configure the database connection</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=OSRSWeapons;Trusted_Connection=true;TrustServerCertificate=true;");

    /// <summary>
    /// Configures the schema and behavior of the weapons entity
    /// </summary>
    /// <param name="modelBuilder">The model builder used to construct the database schema</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Weapon>(entity =>
        {
            entity.Property(e => e.WeaponID).HasColumnName("WeaponID");
            entity.Property(e => e.AttackSpeed).HasDefaultValue(4);
            entity.Property(e => e.Examine).HasMaxLength(255);
            entity.Property(e => e.ImageURL).HasColumnName("ImageURL");
            entity.Property(e => e.Modifiable).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PrimaryAttackType).HasMaxLength(10);
            entity.Property(e => e.RequiredAttackLvl).HasDefaultValue(1);
            entity.Property(e => e.RequiredStrengthLvl).HasDefaultValue(1);
            entity.Property(e => e.SecondaryAttackType).HasMaxLength(10);
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 3)");
        });
    }
}
