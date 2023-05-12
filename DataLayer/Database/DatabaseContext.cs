using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Welcome.Others;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserLog>().Property(e => e.Id).ValueGeneratedOnAdd();
            var user = new DatabaseUser()
            {
                Id = 1,
                Name = "John Doe",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(20)
            };
            var user1 = new DatabaseUser()
            {
                Id = 2,
                Name = "Joe Mama",
                Password = "12345",
                Role = UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddYears(10)
            };
            var user2 = new DatabaseUser()
            {
                Id = 3,
                Name = "Ivan Dragan",
                Password = "12346",
                Role = UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddYears(5)
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user);
            modelBuilder.Entity<DatabaseUser>().HasData(user1);
            modelBuilder.Entity<DatabaseUser>().HasData(user2);
        }

        public DbSet<DatabaseUser> Users { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
    }
}
