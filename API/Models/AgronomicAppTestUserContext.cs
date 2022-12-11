﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class AgronomicAppTestUserContext : DbContext
{
    public AgronomicAppTestUserContext()
    {
    }

    public AgronomicAppTestUserContext(DbContextOptions<AgronomicAppTestUserContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgriculturalMachinery> AgriculturalMachineries { get; set; }

    public virtual DbSet<AgriculturalMachineryType> AgriculturalMachineryTypes { get; set; }

    public virtual DbSet<Chemical> Chemicals { get; set; }

    public virtual DbSet<ChemicalsType> ChemicalsTypes { get; set; }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<Plant> Plants { get; set; }

    public virtual DbSet<PlantsType> PlantsTypes { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

    public virtual DbSet<TaskType> TaskTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = 46.39.232.190; Initial Catalog = Agronomic_App_TestUser;User Id=TestUser; Password=vag!nA228##; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgriculturalMachinery>(entity =>
        {
            entity.HasKey(e => e.IdAgriculturalMachinery);

            entity.ToTable("agricultural_machinery");

            entity.Property(e => e.IdAgriculturalMachinery).HasColumnName("id_agricultural_machinery");
            entity.Property(e => e.AgriculturalMachineryName)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("agricultural_machinery_name");
            entity.Property(e => e.AgriculturalMachineryTypeId).HasColumnName("agricultural_machinery_type_id");

            entity.HasOne(d => d.AgriculturalMachineryType).WithMany(p => p.AgriculturalMachineries)
                .HasForeignKey(d => d.AgriculturalMachineryTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_agricultural_machinery_machinery_types");
        });

        modelBuilder.Entity<AgriculturalMachineryType>(entity =>
        {
            entity.HasKey(e => e.IdAgriculturalMachineryType);

            entity.ToTable("agricultural_machinery_types");

            entity.HasIndex(e => e.AgriculturalMachineryTypeName, "UQ__agricult__A66F73A641E5A270").IsUnique();

            entity.Property(e => e.IdAgriculturalMachineryType).HasColumnName("id_agricultural_machinery_type");
            entity.Property(e => e.AgriculturalMachineryTypeName)
                .HasMaxLength(66)
                .IsUnicode(false)
                .HasColumnName("agricultural_machinery_type_name");
        });

        modelBuilder.Entity<Chemical>(entity =>
        {
            entity.HasKey(e => e.IdChemical);

            entity.ToTable("chemicals");

            entity.HasIndex(e => e.ChemicalName, "UQ__chemical__EFFEEF09339D0D6D").IsUnique();

            entity.Property(e => e.IdChemical).HasColumnName("id_chemical");
            entity.Property(e => e.ChemicalName)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("chemical_name");
            entity.Property(e => e.ChemicalsTypeId).HasColumnName("chemicals_type_id");

            entity.HasOne(d => d.ChemicalsType).WithMany(p => p.Chemicals)
                .HasForeignKey(d => d.ChemicalsTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_chemicals_chemical_types");
        });

        modelBuilder.Entity<ChemicalsType>(entity =>
        {
            entity.HasKey(e => e.IdChemicalType);

            entity.ToTable("chemicals_types");

            entity.HasIndex(e => e.ChemicalTypeName, "UQ__chemical__8FB55F3D90BC73A9").IsUnique();

            entity.Property(e => e.IdChemicalType).HasColumnName("id_chemical_type");
            entity.Property(e => e.ChemicalTypeName)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("chemical_type_name");
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => e.IdField);

            entity.ToTable("fields");

            entity.HasIndex(e => e.FieldIdentifier, "UQ__fields__BE0BB637C374E49C").IsUnique();

            entity.Property(e => e.IdField).HasColumnName("id_field");
            entity.Property(e => e.FieldArea).HasColumnName("field_area");
            entity.Property(e => e.FieldIdentifier)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("field_identifier");
            entity.Property(e => e.FieldPlantId).HasColumnName("field_plant_id");

            entity.HasOne(d => d.FieldPlant).WithMany(p => p.Fields)
                .HasForeignKey(d => d.FieldPlantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_fields_field_plant");
        });

        modelBuilder.Entity<Plant>(entity =>
        {
            entity.HasKey(e => e.IdPlant);

            entity.ToTable("plants");

            entity.HasIndex(e => e.PlantName, "UQ__plants__2D64245385B5C3D6").IsUnique();

            entity.Property(e => e.IdPlant).HasColumnName("id_plant");
            entity.Property(e => e.PlantName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("plant_name");
            entity.Property(e => e.PlantTypeId).HasColumnName("plant_type_id");

            entity.HasOne(d => d.PlantType).WithMany(p => p.Plants)
                .HasForeignKey(d => d.PlantTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_plants_plant_types");
        });

        modelBuilder.Entity<PlantsType>(entity =>
        {
            entity.HasKey(e => e.IdPlantType);

            entity.ToTable("plants_types");

            entity.HasIndex(e => e.PlantTypeName, "UQ__plants_t__76F6DBD2A505DCBB").IsUnique();

            entity.Property(e => e.IdPlantType).HasColumnName("id_plant_type");
            entity.Property(e => e.PlantTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("plant_type_name");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.IdPost);

            entity.ToTable("post");

            entity.HasIndex(e => e.PostName, "UQ__post__7487D7969BC23D11").IsUnique();

            entity.Property(e => e.IdPost).HasColumnName("id_post");
            entity.Property(e => e.PostName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("post_name");
            entity.Property(e => e.SuperiorPostId).HasColumnName("superior_post_id");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.IdTask);

            entity.ToTable("tasks");

            entity.Property(e => e.IdTask).HasColumnName("id_task");
            entity.Property(e => e.TaskDate)
                .HasColumnType("date")
                .HasColumnName("task_date");
            entity.Property(e => e.TaskDescription)
                .IsUnicode(false)
                .HasColumnName("task_description");
            entity.Property(e => e.TaskExecutorId).HasColumnName("task_executor_id");
            entity.Property(e => e.TaskFieldId).HasColumnName("task_field_id");
            entity.Property(e => e.TaskFinishingTime).HasColumnName("task_finishing_time");
            entity.Property(e => e.TaskStartTime).HasColumnName("task_start_time");
            entity.Property(e => e.TaskStatusId).HasColumnName("task_status_id");
            entity.Property(e => e.TaskTypeId).HasColumnName("task_type_id");
            entity.Property(e => e.TaskWeatherInfo)
                .IsUnicode(false)
                .HasColumnName("task_weather_info");

            entity.HasOne(d => d.TaskExecutor).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TaskExecutorId)
                .HasConstraintName("FK_tasks_executor");

            entity.HasOne(d => d.TaskField).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TaskFieldId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tasks_field");

            entity.HasOne(d => d.TaskStatus).WithMany(p => p.Task)
                .HasForeignKey(d => d.TaskStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tasks_status");

            entity.HasOne(d => d.TaskType).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TaskTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tasks_type");
        });

        modelBuilder.Entity<TaskStatus>(entity =>
        {
            entity.HasKey(e => e.IdTaskStatus);

            entity.ToTable("task_statuses");

            entity.HasIndex(e => e.TaskStatusName, "UQ__task_sta__8406F8F92F7DD618").IsUnique();

            entity.Property(e => e.IdTaskStatus).HasColumnName("id_task_status");
            entity.Property(e => e.TaskStatusName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("task_status_name");
        });

        modelBuilder.Entity<TaskType>(entity =>
        {
            entity.HasKey(e => e.IdTaskType);

            entity.ToTable("task_types");

            entity.HasIndex(e => e.TaskTypeName, "UQ__task_typ__AB83C8EBBBBC90FC").IsUnique();

            entity.Property(e => e.IdTaskType).HasColumnName("id_task_type");
            entity.Property(e => e.AgriculturalMachineryId).HasColumnName("agricultural_machinery_id");
            entity.Property(e => e.ChemicalAmount).HasColumnName("chemical_amount");
            entity.Property(e => e.ChemicalId).HasColumnName("chemical_id");
            entity.Property(e => e.SuperiorTypeId).HasColumnName("superior_type_id");
            entity.Property(e => e.TaskTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("task_type_name");

            entity.HasOne(d => d.AgriculturalMachinery).WithMany(p => p.TaskTypes)
                .HasForeignKey(d => d.AgriculturalMachineryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_task_types_agricultural_machinery");

            entity.HasOne(d => d.Chemical).WithMany(p => p.TaskTypes)
                .HasForeignKey(d => d.ChemicalId)
                .HasConstraintName("FK_task_types_chemical");

            entity.HasOne(d => d.SuperiorType).WithMany(p => p.InverseSuperiorType)
                .HasForeignKey(d => d.SuperiorTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_task_types_superior");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("users");

            entity.HasIndex(e => e.UserLogin, "UQ__users__9EA1B5AF97CA1675").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.UserFirstName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("user_first_name");
            entity.Property(e => e.UserLastName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("user_last_name");
            entity.Property(e => e.UserLogin)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("user_login");
            entity.Property(e => e.UserMiddleName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("user_middle_name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("user_password");
            entity.Property(e => e.UserPostId).HasColumnName("user_post_id");

            entity.HasOne(d => d.UserPost).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserPostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_post");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
