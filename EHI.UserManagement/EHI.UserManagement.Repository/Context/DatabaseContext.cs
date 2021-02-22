using EHI.UserManagement.Repository.Configuration;
using EHI.UserManagement.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EHI.UserManagement.Repository.Context
{
    /// <summary>
    /// Databse context class to expose DbSet objects
    /// SaveChanges() method is overriden to include auditing data
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var changeSet = ChangeTracker.Entries<BaseEntity>();

            if (changeSet != null)
            {
                foreach (var entry in changeSet.Where(c => c.State == EntityState.Added))
                {
                    entry.Entity.CreatedOn = DateTime.UtcNow.Date;
                    entry.Entity.ModifiedOn = DateTime.UtcNow.Date;
                }
                foreach (var entry in changeSet.Where(c => c.State == EntityState.Modified))
                {
                    entry.Entity.CreatedOn = entry.Entity.CreatedOn;
                    entry.Entity.ModifiedOn = DateTime.UtcNow.Date;
                }
            }
            return base.SaveChanges();
        }
    }
}
