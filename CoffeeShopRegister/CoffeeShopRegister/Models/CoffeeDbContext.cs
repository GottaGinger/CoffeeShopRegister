using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopRegister.Models;

public partial class CoffeeDbContext : DbContext
{
    public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coffee> Coffees { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coffee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coffee__3214EC0778B0C5DF");

            entity.ToTable("Coffee");

            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0717033178");

            entity.ToTable("Customer");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.OrderName).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
