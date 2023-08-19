using Microsoft.EntityFrameworkCore;
using Tanuljunk.Models;

namespace Tanuljunk.Data;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var weatherForecasts = new List<WeatherForecast>()
        {
            new WeatherForecast()
            {
                Key = Guid.NewGuid(),
                Date = new DateTime(1234, DateTimeKind.Utc), // postgres miatt meg kell mondani explicit a datetimekindot
                Summary = "Meleg van",
                TemperatureC = 32,
            },
            new WeatherForecast()
            {
                Key = Guid.NewGuid(),
                Date = new DateTime(5678, DateTimeKind.Utc),
                Summary = "Hideg van",
                TemperatureC = 3,
            }
        };

        modelBuilder.Entity<WeatherForecast>().HasData(weatherForecasts);
    }
}
