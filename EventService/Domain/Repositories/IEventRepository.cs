using Domain.Entities;

namespace Domain.Repositories;

public interface IEventRepository
{
    public Task<Event?> GetEventByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<Event>> GetEventsAsync(CancellationToken cancellationToken = default);

    public Task DeleteEventAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<Event> AddEventAsync(Event events);

    public Task<Event> UpdateEventAsync(Event events);

}
