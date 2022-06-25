using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnSchoolLine.Data;
using System;

namespace OnlSchoolIne.Infrastructure
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<ClassModel> ClassModels { get; set; }

        public DbSet<GradeModel> GradeModels { get; set; }

        public DbSet<RegisterModel> RegisterModels { get; set; }

        public DbSet<SubjectModel> SubjectModels { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            builder.HasDefaultSchema("dbo");
            builder.HasPostgresExtension("uuid-ossp");

            builder.Entity<ClassModel>()
                .HasOne(x => x.GradeModel)
                .WithMany(x => x.ClassModels)
                .HasForeignKey(x => x.GradeId);

            builder.Entity<AppUser>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<AppUser>()
                .HasOne(x => x.ClassModel)
                .WithMany(x => x.AppUsers)
                .HasForeignKey(x => x.ClassId);

            builder.Entity<SubjectModel>()
                .HasOne(x => x.GradeModel)
                .WithMany(x => x.SubjectModels)
                .HasForeignKey(x => x.GradeId);

            builder.Entity<RegisterModel>()
                .HasKey(x => new { x.SubjectId, x.UserId });

            builder.Entity<RegisterModel>()
                .HasOne(x => x.SubjectModel)
                .WithMany(x => x.RegisterModels)
                .HasForeignKey(x => x.SubjectId);

            builder.Entity<RegisterModel>()
                .HasOne(x => x.UserModel)
                .WithMany(x => x.RegisterModels)
                .HasForeignKey(x => x.UserId);

            base.OnModelCreating(builder);

        }
    }
}