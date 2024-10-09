using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Data;

public partial class CustomerDbContext : DbContext
{
    public CustomerDbContext()
    {
    }

    public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER_DEV;Database=CustomerDb;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07E5D6EFEB");

            entity.ToTable("Customer");

            entity.Property(e => e.CreatedAt).HasColumnType("date");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.EmailAddress).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
