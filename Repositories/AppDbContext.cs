using DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet.Repositories;

public class AppDbContext : DbContext
 {
    public DbSet<Game>? Games { get; set; }
    public DbSet<Gamer>? Gamers { get; set; }
    public DbSet<Attempt>? Attempts {get; set;}
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Game>()
        .HasOne(x => x.Gamer)
        .WithMany(x => x.Games)
        .HasForeignKey(x => x.GamerId);

        builder.Entity<Attempt>()
        .HasOne(x => x.Game)
        .WithMany(x => x.Attempts)
        .HasForeignKey(x => x.GameId);

        builder.Entity<Game>()
        .HasData(new Game
        {
          Id = 1,
          Step = 7,
          RandomNumber = "3456",
          GamerId = 1
        });
         builder.Entity<Gamer>()
        .HasData(new Gamer
        {
          Id = 1,
          Name = "Behzod"
        });
    }
}