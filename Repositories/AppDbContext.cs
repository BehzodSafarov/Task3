using Microsoft.EntityFrameworkCore;
using Task3.Models;

namespace Task3.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<User>? Users {get; set;}
    public DbSet<GameModel>? GameModels {get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<GameModel>()
        .HasOne(x => x.User)
        .WithMany(x => x.NumberModels)
        .HasForeignKey(x => x.UserId);

    }
}