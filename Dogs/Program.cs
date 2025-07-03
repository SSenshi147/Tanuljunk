using Dogs.Data;
using Dogs.Services;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using System.Configuration;

namespace Dogs;

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

        builder.Services.AddDbContext<DogContext>(opt =>
        {
            opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        //builder.Services.AddHostedService<CatConsumerService>();

        builder.Services.AddMassTransit(config =>
        {
            config.AddConsumer<CatConsumer>();

            config.UsingRabbitMq((ctx, conf) =>
            {
                conf.Host("amqp://guest:guest@rabbitmq:5672");

                conf.ReceiveEndpoint("order-queue", c =>
                {
                    c.ConfigureConsumer<CatConsumer>(ctx);
                });
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

            var context = services.GetRequiredService<DogContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        app.Run();
    }
}
