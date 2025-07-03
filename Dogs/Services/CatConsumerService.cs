using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Dogs.Models;
using Dogs.Data;
using MediatR;
using MassTransit;
using Cats.Models;
using Microsoft.EntityFrameworkCore;

namespace Dogs.Services;

public class CatCreatedDest
{
    public Guid Guid { get; set; }
    public string Color { get; set; }
}

public class CatConsumer : IConsumer<CatCreated>
{
    private readonly DogContext dogContext;

    public CatConsumer(DogContext dogContext)
    {
        this.dogContext = dogContext;
    }

    public async Task Consume(ConsumeContext<CatCreated> context)
    {
        var cat = new KnownCat
        {
            Color = context.Message.Color,
            Key = context.Message.Guid
        };

        await this.dogContext.KnownCats.AddAsync(cat);
        await this.dogContext.SaveChangesAsync();
    }
}

public class CatConsumerService : BackgroundService
{
    private readonly IServiceScopeFactory serviceScopeFactory;

    public CatConsumerService(IServiceScopeFactory serviceScopeFactory)
    {
        this.serviceScopeFactory = serviceScopeFactory;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = serviceScopeFactory.CreateScope();
        using var dogContext = scope.ServiceProvider.GetRequiredService<DogContext>();

        var factory = new ConnectionFactory { HostName = "rabbitmq", Port = 5672 };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "hello",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var cat = JsonSerializer.Deserialize<KnownCat>(message);

            dogContext.KnownCats.Add(cat);
            dogContext.SaveChanges();

        };

        channel.BasicConsume(queue: "hello",
                             autoAck: true,
                             consumer: consumer);

        return Task.CompletedTask;
    }
}