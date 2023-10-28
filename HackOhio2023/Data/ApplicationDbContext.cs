using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HackOhio2023.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Event>? Events { get; set; }  
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-HackOhio2023;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Event>()
            .HasMany(e => e.Participants)
            .WithMany(e => e.Events);
        }

  
    }
}