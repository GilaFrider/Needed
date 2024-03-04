using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Models;

public partial class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Criterion> Criteria { get; set; }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<FieldOfWork> FieldOfWorks { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Criterion>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__criteria__357D4CF8D4AE569C");

            entity.ToTable("criteria");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Descriptions)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.NumberOfCvsSent).HasColumnName("NumberOfCVsSent");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Employer__357D4CF86661B612");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CompanyAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("lastname");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("phone");
        });

        modelBuilder.Entity<FieldOfWork>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__fieldOfW__357D4CF8018C4388");

            entity.ToTable("fieldOfWork");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.FieldOfWorkName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("fieldOfWorkName");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Jobs__357D4CF8AD19CB79");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CriteriaCode).HasColumnName("criteriaCode");
            entity.Property(e => e.FieldOfWorkCode).HasColumnName("fieldOfWorkCode");

            entity.HasOne(d => d.CriteriaCodeNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.CriteriaCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Jobs_Tocriteria");

            entity.HasOne(d => d.EmployersCodeNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.EmployersCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Jobs_ToEmployers");

            entity.HasOne(d => d.FieldOfWorkCodeNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.FieldOfWorkCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Jobs_TofieldOfWork");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
