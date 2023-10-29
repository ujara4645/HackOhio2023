using HackOhio2023.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace HackOhio2023.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<ApplicationUser>? ApplicationUser { get; set; }

    public DbSet<Event>? Events { get; set; }

    public DbSet<ApplicationUserEvent>? ApplicationUserEvents { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationUser>()
            .HasMany(e => e.Events)
            .WithMany(e => e.Participants)
            .UsingEntity<ApplicationUserEvent>();
    }
}