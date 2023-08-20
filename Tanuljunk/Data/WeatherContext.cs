using Microsoft.EntityFrameworkCore;
using Tanuljunk.Models;

namespace Tanuljunk.Data;

public class WeatherContext : DbContext
{
    public WeatherContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Weather> WeatherForecasts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var weatherForecasts = new List<Weather>()
        {
            new Weather()
            {
                Key = Guid.NewGuid(),
                Date = new DateTime(1234, DateTimeKind.Utc), // postgres miatt meg kell mondani explicit a datetimekindot
                Summary = "Meleg van",
                TemperatureC = 32,
            },
            new Weather()
            {
                Key = Guid.NewGuid(),
                Date = new DateTime(5678, DateTimeKind.Utc),
                Summary = "Hideg van",
                TemperatureC = 3,
            }
        };

        modelBuilder.Entity<Weather>().HasData(weatherForecasts);
    }
}
