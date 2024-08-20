using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models;

public partial class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<FieldsOfWork> FieldsOfWorks { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__employer__357D4CF8322A69C6");

            entity.ToTable("employers");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CompanyAddress)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("companyAddress");
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("companyName");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<FieldsOfWork>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__fieldsOf__357D4CF85495DA0D");

            entity.ToTable("fieldsOfWork");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.FieldOfWorkName)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("fieldOfWorkName");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__jobs__357D4CF87C71E2E0");

            entity.ToTable("jobs");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EmployerCode).HasColumnName("employerCode");
            entity.Property(e => e.FieldOfWorkCode).HasColumnName("fieldOfWorkCode");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.SeveralYearsOfExperience).HasColumnName("severalYearsOfExperience");

            entity.HasOne(d => d.EmployerCodeNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.EmployerCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_jobs_Toemployers");

            entity.HasOne(d => d.FieldOfWorkCodeNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.FieldOfWorkCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_jobs_TofieldsOfWork");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
