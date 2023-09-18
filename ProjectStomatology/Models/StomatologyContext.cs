using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectStomatology.Models
{
    public partial class StomatologyContext : DbContext
    {
        public StomatologyContext()
        {
        }

        public StomatologyContext(DbContextOptions<StomatologyContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Cspecialty> Cspecialties { get; set; } = null!;
        public virtual DbSet<DdiseaseHistory> DdiseaseHistories { get; set; } = null!;
        public virtual DbSet<JdiseaseHistory> JdiseaseHistories { get; set; } = null!;
        public virtual DbSet<Rclient> Rclients { get; set; } = null!;
        public virtual DbSet<Sperson> Speople { get; set; } = null!;
        public virtual DbSet<VisitHistory> VisitHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Stomatology;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AspNetRole>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedName] IS NOT NULL)");

            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetRoleClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetRoleClaims)
            //        .HasForeignKey(d => d.RoleId);
            //});

            //modelBuilder.Entity<AspNetUser>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            //    entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.EmailConfirmed)
            //        .IsRequired()
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserName).HasMaxLength(256);

            //    entity.HasMany(d => d.Roles)
            //        .WithMany(p => p.Users)
            //        .UsingEntity<Dictionary<string, object>>(
            //            "AspNetUserRole",
            //            l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
            //            r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
            //            j =>
            //            {
            //                j.HasKey("UserId", "RoleId");

            //                j.ToTable("AspNetUserRoles");

            //                j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
            //            });
            //});

            //modelBuilder.Entity<AspNetUserClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserClaims)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserLogin>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            //    entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.ProviderKey).HasMaxLength(128);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserLogins)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserToken>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.Name).HasMaxLength(128);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserTokens)
            //        .HasForeignKey(d => d.UserId);
            //});

            modelBuilder.Entity<Cspecialty>(entity =>
            {
                entity.ToTable("CSpecialties");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<DdiseaseHistory>(entity =>
            {
                entity.ToTable("DDiseaseHistory");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.DdiseaseHistories)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_DDiseaseHistory_DDiseaseHistory");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.DdiseaseHistories)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_DDiseaseHistory_SPerson");
            });

            modelBuilder.Entity<JdiseaseHistory>(entity =>
            {
                entity.ToTable("JDiseaseHistory");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.JdiseaseHistories)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_JDiseaseHistory_RClient");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.JdiseaseHistories)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_JDiseaseHistory_SPerson");
            });

            modelBuilder.Entity<Rclient>(entity =>
            {
                entity.ToTable("RClient");

                entity.Property(e => e.Dentist).HasMaxLength(150);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Payment).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.PolicyNumber).HasMaxLength(50);

                entity.Property(e => e.Snils)
                    .HasMaxLength(50)
                    .HasColumnName("SNILS");

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<Sperson>(entity =>
            {
                entity.ToTable("SPerson");

                entity.Property(e => e.AspNetUserEmail).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<VisitHistory>(entity =>
            {
                entity.ToTable("VisitHistory");

                entity.Property(e => e.DatetimeVisit).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.VisitHistories)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VisitHistory_RClient");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.VisitHistories)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VisitHistory_SPerson");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
