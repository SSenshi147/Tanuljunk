using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tanuljunk.Data;

namespace Tanuljunk;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<MainContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        }, ServiceLifetime.Scoped);


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();


        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<MainContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        app.Run();
    }
}
