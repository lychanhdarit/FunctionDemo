using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Data.Repository.Models;

namespace Data.Repository
{
    public partial class dbDataContext : DbContext
    {
        public dbDataContext()
        {
        }

        public dbDataContext(DbContextOptions<dbDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public virtual DbSet<FranchiseeModule> FranchiseeModules { get; set; } = null!;
        public virtual DbSet<FranchiseeTenant> FranchiseeTenants { get; set; } = null!;
        public virtual DbSet<GridConfig> GridConfigs { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Module> Modules { get; set; } = null!;
        public virtual DbSet<ModuleDocumentType> ModuleDocumentTypes { get; set; } = null!;
        public virtual DbSet<SecurityOperation> SecurityOperations { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<Template> Templates { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<UserRoleFunction> UserRoleFunctions { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    { 
        //        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=HarmonyAdmin;MultipleActiveResultSets=true;User ID=sa;Password=Vn@2022@;TrustServerCertificate=True");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<FranchiseeModule>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Franchisee)
                    .WithMany(p => p.FranchiseeModules)
                    .HasForeignKey(d => d.FranchiseeId)
                    .HasConstraintName("FK_Franchisee_Module_FranchiseeTenant");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.FranchiseeModules)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK_Franchisee_Module_Module");
            });

            modelBuilder.Entity<FranchiseeTenant>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<GridConfig>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.GridConfigs)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK_GridConfig_DocumentType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GridConfigs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GridConfig_User");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_State");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ModuleDocumentType>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.ModuleDocumentTypes)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK_Module_DocumentType_Operation_DocumentType");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.ModuleDocumentTypes)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK_Module_DocumentType_Operation_Module");
            });

            modelBuilder.Entity<SecurityOperation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.GroupKeySearch).IsFixedLength();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_User_Location1");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_User_UserRole");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UserRoleFunction>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.UserRoleFunctions)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK_UserRoleFunction_DocumentType");

                entity.HasOne(d => d.SecurityOperation)
                    .WithMany(p => p.UserRoleFunctions)
                    .HasForeignKey(d => d.SecurityOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoleFunction_SecurityOperation");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.UserRoleFunctions)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("FK_UserRoleFunction_UserRole");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
