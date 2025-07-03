using Cats.Data;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace Cats;

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

        builder.Services.AddDbContext<CatContext>(opt =>
        {
            opt.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!);
        });

        builder.Services.AddMassTransit(config =>
        {
            config.UsingRabbitMq((a, b) =>
            {
                //b.Host(host: "rabbitmq", port: 5672, virtualHost: "/", connectionName: "rabbitmq", conf =>
                //{
                //    conf.Username("guest");
                //    conf.Password("guest");
                //});

                b.Host("amqp://guest:guest@rabbitmq:5672");

                b.ConfigureEndpoints(a);
            });
        });

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

            var context = services.GetRequiredService<CatContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        app.Run();
    }
}
