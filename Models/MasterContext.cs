using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cat> Cats { get; set; }

    public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = 46.39.232.190; Initial Catalog = master;User Id=TestUser; Password=vag!nA228##; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cat>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cats");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Ves).HasColumnName("ves");
        });

        modelBuilder.Entity<TaskStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("task_statuses");

            entity.HasIndex(e => e.TaskStatusName, "UQ__task_sta__8406F8F9AB259C0C").IsUnique();

            entity.Property(e => e.TaskStatusName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("task_status_name");
            entity.Property(e => e.TaskStatuseId).HasColumnName("task_statuse_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
