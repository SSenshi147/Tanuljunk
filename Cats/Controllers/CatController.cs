using Cats.Data;
using Cats.Models;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Cats.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CatController : ControllerBase
{
    private readonly CatContext catContext;
    private readonly IPublishEndpoint publishEndpoint;

    public CatController(
        CatContext catContext,
        IPublishEndpoint publishEndpoint)
    {
        this.catContext = catContext;
        this.publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    public async Task<List<Cat>> GetCats()
    {
        return await this.catContext.Cats.ToListAsync(this.HttpContext.RequestAborted);
    }

    [HttpPost]
    public async Task<Cat> CreateCat([FromBody] CreateCatModel createCatModel)
    {
        var cat = new Cat
        {
            Color = createCatModel.Color,
            Name = createCatModel.Name,
            Key = Guid.NewGuid()
        };

        await this.catContext.Cats.AddAsync(cat, this.HttpContext.RequestAborted);
        //await this.catContext.SaveChangesAsync(this.HttpContext.RequestAborted);

        PublishNewCat(cat);

        return cat;
    }

    private  void PublishNewCat(Cat cat)
    {
        //var factory = new ConnectionFactory { HostName = "rabbitmq", Port = 5672 };
        //using var connection = factory.CreateConnection();
        //using var channel = connection.CreateModel();

        //channel.QueueDeclare(queue: "hello",
        //                     durable: false,
        //                     exclusive: false,
        //                     autoDelete: false,
        //                     arguments: null);

        //var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(cat));

        //channel.BasicPublish(exchange: string.Empty,
        //                     routingKey: "hello",
        //                     basicProperties: null,
        //                     body: body);

        this.publishEndpoint.Publish(new CatCreated()
        {
            Color = cat.Color,
            Guid = cat.Key
        });
    }
}
