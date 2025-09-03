using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MedicalStoreManagement.Models;

public partial class MedicalStoreManagementContext : DbContext
{
    public MedicalStoreManagementContext()
    {
    }

    public MedicalStoreManagementContext(DbContextOptions<MedicalStoreManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<MedcinineStock> MedcinineStocks { get; set; }

    public virtual DbSet<Purchasing> Purchasings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DBConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE488DE23E2D5");

            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phoneno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phoneno");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK__Customer__9725F2C6F95AF73B");

            entity.Property(e => e.CustId)
                .ValueGeneratedNever()
                .HasColumnName("custId");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phoneno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phoneno");
        });

        modelBuilder.Entity<MedcinineStock>(entity =>
        {
            entity.HasKey(e => e.MedId).HasName("PK__Medcinin__EB77FC56AF5D0BB2");

            entity.ToTable("MedcinineStock");

            entity.Property(e => e.MedId).ValueGeneratedNever();
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MedCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MedName)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Purchasing>(entity =>
        {
            entity.HasKey(e => e.PurchasingId).HasName("PK__Purchasi__76CF1128749565E0");

            entity.ToTable("Purchasing");

            entity.Property(e => e.PurchasingId)
                .ValueGeneratedNever()
                .HasColumnName("purchasingId");

            entity.HasOne(d => d.Med).WithMany(p => p.Purchasings)
                .HasForeignKey(d => d.MedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Purchasin__MedId__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
