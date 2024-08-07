﻿using demo_azure_deployment.Models;
using Microsoft.EntityFrameworkCore;

namespace demo_azure_deployment.Config
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _config;
        public AppDbContext(IConfiguration config) : base()
        {
            _config = config;
        }

        public DbSet<Person> People { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedTime)
                    .IsRequired()
                    .HasColumnType("datetime");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_config.GetConnectionString("AppDbMySql"));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State is EntityState.Added && entry.Entity is BaseProp entity)
                {
                    entity.CreatedTime = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
