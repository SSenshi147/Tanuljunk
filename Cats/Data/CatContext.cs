using Cats.Models;
using Microsoft.EntityFrameworkCore;

namespace Cats.Data;

public class CatContext : DbContext
{
    public CatContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Cat> Cats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var cats = new List<Cat>()
        {
            new Cat()
            {
                Key = Guid.NewGuid(),
                Color = "orange",
                Name = "very dumb cat",
            },
            new Cat()
            {
                Key = Guid.NewGuid(),
                Color = "black",
                Name = "smart cat",
            }
        };

        modelBuilder.Entity<Cat>().HasData(cats);
    }
}