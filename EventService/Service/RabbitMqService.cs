using System.Text;
using System.Text.Json;
using Contract;
using RabbitMQ.Client;
using Services.Abstractions;

namespace Service;

public class RabbitMqService : IRabbitMqService
{
    private readonly String hostname;

    public RabbitMqService(string hostname)
    {
        this.hostname = hostname;
    }

    public void SendMessage(EventDTO events)
    {
        var factory = new ConnectionFactory() { HostName = hostname };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "email-queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var message = JsonSerializer.Serialize(events);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "emailExchange",
                                 routingKey: "emailRoutingKey",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine($" [x] Sent {message}");
        }
    }
}
