using AdvancedTaskControl.API.Models;
using AdvancedTaskControl.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace AdvancedTaskControl.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(
                us =>
                {
                    us.Property(u => u.Id).ValueGeneratedOnAdd();
                    us.HasIndex(u => u.Username).IsUnique();
                }
            );
 
            modelBuilder.Entity<UserTask>(
                us =>
                {
                    us.Property(ut => ut.Id).ValueGeneratedOnAdd();
                }
            );

            modelBuilder.Entity<UserTask>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTasks)
                .HasForeignKey(ut => ut.UserId);

            modelBuilder.Entity<UserTask>()
                .HasOne(u => u.Category)
                .WithMany(c => c.UserTasks)
                .HasForeignKey(u => u.CategoryId);

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = -9991,
                        Username = "Admin",
                        Password = BC.HashPassword("123"),
                        Role = "ADM"
                    },
                    new User
                    {
                        Id = -9992,
                        Username = "User",
                        Password = BC.HashPassword("123"),
                        Role = "USER"
                    }
            );

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category
                    {
                        Id = 1,
                        CategoryDescription = "Categoria 1"
                    },
                    new Category
                    {
                        Id = 2,
                        CategoryDescription = "Categoria 2"
                    },
                    new Category
                    {
                        Id = 3,
                        CategoryDescription = "Categoria 3"
                    }
                );
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var AddedEntities = ChangeTracker.Entries()
                .Where(E => E.Entity.GetType().GetProperty("CreatedDate") != null && E.State == EntityState.Added)
                .ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedDate").CurrentValue = DateTime.Now;
            });

            var EditedEntities = ChangeTracker.Entries()
                .Where(E => E.Entity.GetType().GetProperty("ModifiedDate") != null && E.State == EntityState.Modified)
                .ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property("ModifiedDate").CurrentValue = DateTime.Now;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
