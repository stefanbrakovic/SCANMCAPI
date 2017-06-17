using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TeretanaAPI.Models
{
    public partial class TeretanaContext : DbContext
    {
        public virtual DbSet<Contains> Contains { get; set; }
        public virtual DbSet<Genders> Genders { get; set; }
        public virtual DbSet<Packages> Packages { get; set; }
        public virtual DbSet<Provides> Provides { get; set; }
        public virtual DbSet<ServicePrice> ServicePrice { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Subscribed> Subscribed { get; set; }
        public virtual DbSet<UserTypes> UserTypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Uses> Uses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7P9Q534;Database=Teretana;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contains>(entity =>
            {
                entity.Property(e => e.ContainsId).ValueGeneratedNever();

                entity.Property(e => e.DateAdded)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal")
                    .HasDefaultValueSql("0.00");
            });

            modelBuilder.Entity<Genders>(entity =>
            {
                entity.HasKey(e => e.GenderId)
                    .HasName("PK__Genders__4E24E9F7FCA75C50");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Packages>(entity =>
            {
                entity.HasKey(e => e.PackageId)
                    .HasName("PK__Packages__322035CC28ECDB8F");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnType("binary(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.PackageDescription)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'Opis paketa'");

                entity.Property(e => e.PackageName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Provides>(entity =>
            {
                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateTo).HasColumnType("datetime");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Provides)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Provides_Services");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Provides)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Provides_Users");
            });

            modelBuilder.Entity<ServicePrice>(entity =>
            {
                entity.HasKey(e => e.ServiceId)
                    .HasName("PK_ServicePrice");

                entity.Property(e => e.ServiceId).ValueGeneratedNever();

                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Price).HasColumnType("decimal");

                entity.HasOne(d => d.Service)
                    .WithOne(p => p.ServicePrice)
                    .HasForeignKey<ServicePrice>(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ServicePrice_Services");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId)
                    .HasName("PK__Services__C51BB00AD346CE8B");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.IsActive).HasDefaultValueSql("0");

                entity.Property(e => e.ServiceDescription).HasMaxLength(250);

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Subscribed>(entity =>
            {
                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.DateTo).HasColumnType("datetime");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Subscribed)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Subscribed_Package");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Subscribed)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Subscribed_Users");
            });

            modelBuilder.Entity<UserTypes>(entity =>
            {
                entity.HasKey(e => e.UserTypeId)
                    .HasName("PK_UserTypes");

                entity.Property(e => e.TypeDescription).HasMaxLength(30);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C027D74C6");

                entity.HasIndex(e => e.CardNumber)
                    .HasName("UQ__Users__4CD3FAA21917D4A3")
                    .IsUnique();

                entity.HasIndex(e => e.Mail)
                    .HasName("UQ__Users__2724B2D16C5A912B")
                    .IsUnique();

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.DateOfRegistration).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.StreetNumber).HasMaxLength(50);

                entity.Property(e => e.Telephone).HasMaxLength(25);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Uses>(entity =>
            {
                entity.HasKey(e => e.UsageId)
                    .HasName("PK__Uses__29B197203CA8E4DB");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateTo).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Uses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Uses_Users");
            });
        }
    }

}