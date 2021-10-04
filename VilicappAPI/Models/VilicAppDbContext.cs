using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class VilicAppDbContext : DbContext
    {
        public VilicAppDbContext()
        {
        }

        public VilicAppDbContext(DbContextOptions<VilicAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<ForkLift> ForkLifts { get; set; }
        public virtual DbSet<ForkLiftRent> ForkLiftRents { get; set; }
        public virtual DbSet<ForkLiftType> ForkLiftTypes { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<MaterialConsumption> MaterialConsumptions { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }
        public virtual DbSet<RentDetail> RentDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Transportation> Transportations { get; set; }
        public virtual DbSet<TransportationRent> TransportationRents { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<WorkOrderRent> WorkOrderRents { get; set; }
        public virtual DbSet<WorkOrderRepair> WorkOrderRepairs { get; set; }
        public virtual DbSet<WorkOrderStatus> WorkOrderStatuses { get; set; }
        public virtual DbSet<WorkOrderTransport> WorkOrderTransports { get; set; }
        public virtual DbSet<WorkTimeConsumption> WorkTimeConsumptions { get; set; }
        public virtual DbSet<WorkTimeType> WorkTimeTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=VilicAppDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Slovenian_100_CI_AS");

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("Attachment");

                entity.Property(e => e.BinaryData).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.WorkOrderRepair)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.WorkOrderRepairId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attachmen__WorkO__02084FDA");
            });

            modelBuilder.Entity<ForkLift>(entity =>
            {
                entity.ToTable("ForkLift");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.InternalNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ForkLiftType)
                    .WithMany(p => p.ForkLifts)
                    .HasForeignKey(d => d.ForkLiftTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ForkLift__ForkLi__02FC7413");
            });

            modelBuilder.Entity<ForkLiftRent>(entity =>
            {
                entity.ToTable("ForkLiftRent");

                entity.Property(e => e.Client)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EndRent).HasColumnType("datetime");

                entity.Property(e => e.Lat).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Lng).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.StartRent).HasColumnType("datetime");

                entity.HasOne(d => d.ForkLift)
                    .WithMany(p => p.ForkLiftRents)
                    .HasForeignKey(d => d.ForkLiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ForkLiftR__ForkL__03F0984C");
            });

            modelBuilder.Entity<ForkLiftType>(entity =>
            {
                entity.ToTable("ForkLiftType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.BinaryData).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.WorkOrderRepair)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.WorkOrderRepairId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Image__WorkOrder__04E4BC85");
            });

            modelBuilder.Entity<MaterialConsumption>(entity =>
            {
                entity.ToTable("MaterialConsumption");

                entity.Property(e => e.Material)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PriceTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.WorkOrderRepair)
                    .WithMany(p => p.MaterialConsumptions)
                    .HasForeignKey(d => d.WorkOrderRepairId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MaterialC__WorkO__05D8E0BE");
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.ToTable("OrderType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RentDetail>(entity =>
            {
                entity.ToTable("RentDetail");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PriceTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RentDays).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.WorkOrderRent)
                    .WithMany(p => p.RentDetails)
                    .HasForeignKey(d => d.WorkOrderRentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RentDetai__WorkO__06CD04F7");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transportation>(entity =>
            {
                entity.ToTable("Transportation");

                entity.Property(e => e.Kilometers).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PriceTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Relation)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.WorkOrderRepair)
                    .WithMany(p => p.Transportations)
                    .HasForeignKey(d => d.WorkOrderRepairId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transport__WorkO__07C12930");
            });

            modelBuilder.Entity<TransportationRent>(entity =>
            {
                entity.ToTable("TransportationRent");

                entity.Property(e => e.Kilometers).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PriceTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Relation)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.WorkOrderRent)
                    .WithMany(p => p.TransportationRents)
                    .HasForeignKey(d => d.WorkOrderRentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transport__WorkO__08B54D69");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__RoleId__09A971A2");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.ToTable("VehicleType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkOrderRent>(entity =>
            {
                entity.ToTable("WorkOrderRent");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RentEnd).HasColumnType("datetime");

                entity.Property(e => e.RentStart).HasColumnType("datetime");

                entity.Property(e => e.TaxNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ModifiedByUser)
                    .WithMany(p => p.WorkOrderRents)
                    .HasForeignKey(d => d.ModifiedByUserId)
                    .HasConstraintName("FK__WorkOrder__Modif__0B91BA14");

                entity.HasOne(d => d.WorkOrderStatus)
                    .WithMany(p => p.WorkOrderRents)
                    .HasForeignKey(d => d.WorkOrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkOrder__WorkO__0A9D95DB");
            });

            modelBuilder.Entity<WorkOrderRepair>(entity =>
            {
                entity.ToTable("WorkOrderRepair");

                entity.Property(e => e.Client)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EndWork).HasColumnType("datetime");

                entity.Property(e => e.ForkliftName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Recieved).HasColumnType("datetime");

                entity.Property(e => e.TaxNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ModifiedByUser)
                    .WithMany(p => p.WorkOrderRepairs)
                    .HasForeignKey(d => d.ModifiedByUserId)
                    .HasConstraintName("FK__WorkOrder__Modif__0E6E26BF");

                entity.HasOne(d => d.OrderType)
                    .WithMany(p => p.WorkOrderRepairs)
                    .HasForeignKey(d => d.OrderTypeId)
                    .HasConstraintName("FK__WorkOrder__Order__0C85DE4D");

                entity.HasOne(d => d.WorkOrderStatus)
                    .WithMany(p => p.WorkOrderRepairs)
                    .HasForeignKey(d => d.WorkOrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkOrder__WorkO__0D7A0286");
            });

            modelBuilder.Entity<WorkOrderStatus>(entity =>
            {
                entity.ToTable("WorkOrderStatus");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkOrderTransport>(entity =>
            {
                entity.ToTable("WorkOrderTransport");

                entity.Property(e => e.AdditionalWorkPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AsistanceHourPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AsistanceHours).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Brand)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LicenseNr)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RelationKm).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RelationKmPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RelationName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TaxNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ToolsQtyPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WorkOrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.ModifiedByUser)
                    .WithMany(p => p.WorkOrderTransports)
                    .HasForeignKey(d => d.ModifiedByUserId)
                    .HasConstraintName("FK__WorkOrder__Modif__10566F31");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.WorkOrderTransports)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .HasConstraintName("FK__WorkOrder__Vehic__114A936A");

                entity.HasOne(d => d.WorkOrderStatus)
                    .WithMany(p => p.WorkOrderTransports)
                    .HasForeignKey(d => d.WorkOrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkOrder__WorkO__0F624AF8");
            });

            modelBuilder.Entity<WorkTimeConsumption>(entity =>
            {
                entity.ToTable("WorkTimeConsumption");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Hours).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PriceTotal).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.WorkOrderRepair)
                    .WithMany(p => p.WorkTimeConsumptions)
                    .HasForeignKey(d => d.WorkOrderRepairId)
                    .HasConstraintName("FK__WorkTimeC__WorkO__123EB7A3");

                entity.HasOne(d => d.WorkTimeType)
                    .WithMany(p => p.WorkTimeConsumptions)
                    .HasForeignKey(d => d.WorkTimeTypeId)
                    .HasConstraintName("FK__WorkTimeC__WorkT__1332DBDC");
            });

            modelBuilder.Entity<WorkTimeType>(entity =>
            {
                entity.ToTable("WorkTimeType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
