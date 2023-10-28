using HackOhio2023.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HackOhio2023.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<User>? Users { get; set; }
        public DbSet<ApplicationUser>? ApplicationUser { get; set; }

        public DbSet<Event>? Events { get; set; }

        public string DbPath { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DbPath = Path.Join(path, "hackohio2023.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Event>()
        //        .HasMany(e => e.Participants)
        //        .WithMany(e => e.Events);
        //}


    }
}