using Dogs.Models;
using Microsoft.EntityFrameworkCore;

namespace Dogs.Data;

public class DogContext : DbContext
{
    public DogContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Dog> Dogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var dogs = new List<Dog>()
        {
            new Dog()
            {
                Key = Guid.NewGuid(),
                CanDoTricks = true,
                Name = "okos kutya",
            },
            new Dog()
            {
                Key = Guid.NewGuid(),
                CanDoTricks = false,
                Name = "buta kutya",
            }
        };

        modelBuilder.Entity<Dog>().HasData(dogs);
    }
}
