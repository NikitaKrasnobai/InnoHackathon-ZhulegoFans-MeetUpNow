using Contract;

namespace Services.Abstractions;

public interface IRabbitMqService
{
    void SendMessage(EventDTO events);
}
