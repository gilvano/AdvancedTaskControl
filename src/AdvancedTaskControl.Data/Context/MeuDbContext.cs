using AdvancedTaskControl.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(
                us =>
                {
                    us.Property(u => u.Id).ValueGeneratedOnAdd();
                    us.HasIndex(u => u.Username).IsUnique();
                }
            );

             modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = -9991,
                        Username = "Admin",
                        Password = "123",
                        Role = "ADM"
                    },
                    new User
                    {
                        Id = -9992,
                        Username = "User",
                        Password = "123",
                        Role = "USER"
                    }
            );
        }
    }
}
