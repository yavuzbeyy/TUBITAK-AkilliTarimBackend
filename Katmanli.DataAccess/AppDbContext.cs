using Katmanli.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Bitki> Bitkiler { get; set; }

        public DbSet<Gubreleme> Gubreler { get; set; }

        public DbSet<Iklim> Iklimler { get; set; }

        public DbSet<Sehir> Sehirler { get; set; }

        public DbSet<Sulama> Sulamalar { get; set; }

        public DbSet<Toprak> Topraklar { get; set; }

        public DbSet<SehirBitki> SehirVeBitkiler { get; set; }

        public DbSet<UploadImage> UploadImages { get; set; }

        // Default olarak Admin ve Kullanıcı rollerini Seed data olarak ata.

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    RoleName = "Admin",
                    CreatedDate = DateTime.Now,
                },
                new Role
                {
                    Id = 2,
                    RoleName = "User",
                    CreatedDate = DateTime.Now,
                }
            );
        }
    }
}
