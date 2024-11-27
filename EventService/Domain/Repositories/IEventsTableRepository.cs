using Domain.Entities;

namespace Domain.Repositories;

public interface IEventsTableRepository
{
    public Task<EventsTable?> GetEventsTableByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<EventsTable>> GetEventsTablesAsync(CancellationToken cancellationToken = default);

    public Task DeleteEventsTableAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<EventsTable> AddEventsTableAsync(EventsTable eventsTable);

    public Task<EventsTable> UpdateEventsTableAsync(EventsTable eventsTable);
}
