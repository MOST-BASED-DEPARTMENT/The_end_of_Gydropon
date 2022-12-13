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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationBuilder? builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
    }


    public virtual DbSet<AgriculturalMachinery> AgriculturalMachineries { get; set; }

    public virtual DbSet<AgriculturalMachineryType> AgriculturalMachineryTypes { get; set; }

    public virtual DbSet<Chemical> Chemicals { get; set; }

    public virtual DbSet<ChemicalsType> ChemicalsTypes { get; set; }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<Plant> Plants { get; set; }

    public virtual DbSet<PlantsType> PlantsTypes { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Ttask> Ttasks { get; set; }

    public virtual DbSet<TtaskStatus> TtaskStatuses { get; set; }

    public virtual DbSet<TtaskType> TtaskTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

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

            entity.HasIndex(e => e.AgriculturalMachineryTypeName, "UQ__agricult__A66F73A607F4B53C").IsUnique();

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

            entity.HasIndex(e => e.ChemicalName, "UQ__chemical__EFFEEF09B5BBEA66").IsUnique();

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

            entity.HasIndex(e => e.ChemicalTypeName, "UQ__chemical__8FB55F3DF8545876").IsUnique();

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

            entity.HasIndex(e => e.FieldIdentifier, "UQ__fields__BE0BB63723A4FDD0").IsUnique();

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

            entity.HasIndex(e => e.PlantName, "UQ__plants__2D642453033F0DA6").IsUnique();

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

            entity.HasIndex(e => e.PlantTypeName, "UQ__plants_t__76F6DBD2BB307452").IsUnique();

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

            entity.HasIndex(e => e.PostName, "UQ__post__7487D796ACAB5998").IsUnique();

            entity.Property(e => e.IdPost).HasColumnName("id_post");
            entity.Property(e => e.PostName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("post_name");
            entity.Property(e => e.SuperiorPostId).HasColumnName("superior_post_id");
        });

        modelBuilder.Entity<Ttask>(entity =>
        {
            entity.HasKey(e => e.IdTtask);

            entity.ToTable("ttasks");

            entity.Property(e => e.IdTtask).HasColumnName("id_ttask");
            entity.Property(e => e.TtaskDate)
                .HasColumnType("date")
                .HasColumnName("ttask_date");
            entity.Property(e => e.TtaskDescription)
                .IsUnicode(false)
                .HasColumnName("ttask_description");
            entity.Property(e => e.TtaskExecutorId).HasColumnName("ttask_executor_id");
            entity.Property(e => e.TtaskFieldId).HasColumnName("ttask_field_id");
            entity.Property(e => e.TtaskFinishingTime).HasColumnName("ttask_finishing_time");
            entity.Property(e => e.TtaskStartTime).HasColumnName("ttask_start_time");
            entity.Property(e => e.TtaskStatusId).HasColumnName("ttask_status_id");
            entity.Property(e => e.TtaskTypeId).HasColumnName("ttask_type_id");
            entity.Property(e => e.TtaskWeatherInfo)
                .IsUnicode(false)
                .HasColumnName("ttask_weather_info");

            entity.HasOne(d => d.TtaskExecutor).WithMany(p => p.Ttasks)
                .HasForeignKey(d => d.TtaskExecutorId)
                .HasConstraintName("FK_ttasks_executor");

            entity.HasOne(d => d.TtaskField).WithMany(p => p.Ttasks)
                .HasForeignKey(d => d.TtaskFieldId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ttasks_field");

            entity.HasOne(d => d.TtaskStatus).WithMany(p => p.Ttasks)
                .HasForeignKey(d => d.TtaskStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ttasks_status");

            entity.HasOne(d => d.TtaskType).WithMany(p => p.Ttasks)
                .HasForeignKey(d => d.TtaskTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ttasks_type");
        });

        modelBuilder.Entity<TtaskStatus>(entity =>
        {
            entity.HasKey(e => e.IdTtaskStatus);

            entity.ToTable("ttask_statuses");

            entity.HasIndex(e => e.TtaskStatusName, "UQ__ttask_st__A11F8A00DA93E2D3").IsUnique();

            entity.Property(e => e.IdTtaskStatus).HasColumnName("id_ttask_status");
            entity.Property(e => e.TtaskStatusName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ttask_status_name");
        });

        modelBuilder.Entity<TtaskType>(entity =>
        {
            entity.HasKey(e => e.IdTtaskType);

            entity.ToTable("ttask_types");

            entity.HasIndex(e => e.TtaskTypeName, "UQ__ttask_ty__93E733226B7080E7").IsUnique();

            entity.Property(e => e.IdTtaskType).HasColumnName("id_ttask_type");
            entity.Property(e => e.AgriculturalMachineryId).HasColumnName("agricultural_machinery_id");
            entity.Property(e => e.ChemicalAmount).HasColumnName("chemical_amount");
            entity.Property(e => e.ChemicalId).HasColumnName("chemical_id");
            entity.Property(e => e.SuperiorTypeId).HasColumnName("superior_type_id");
            entity.Property(e => e.TtaskTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ttask_type_name");

            entity.HasOne(d => d.AgriculturalMachinery).WithMany(p => p.TtaskTypes)
                .HasForeignKey(d => d.AgriculturalMachineryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ttask_types_agricultural_machinery");

            entity.HasOne(d => d.Chemical).WithMany(p => p.TtaskTypes)
                .HasForeignKey(d => d.ChemicalId)
                .HasConstraintName("FK_ttask_types_chemical");

            entity.HasOne(d => d.SuperiorType).WithMany(p => p.InverseSuperiorType)
                .HasForeignKey(d => d.SuperiorTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ttask_types_superior");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("users");

            entity.HasIndex(e => e.UserLogin, "UQ__users__9EA1B5AF7999888D").IsUnique();

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
