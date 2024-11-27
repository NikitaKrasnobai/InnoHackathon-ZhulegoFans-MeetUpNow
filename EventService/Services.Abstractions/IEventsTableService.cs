using Contract;

namespace Services.Abstractions;

public interface IEventsTableService
{
    public Task<EventsTableDTO?> GetEventsTableByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<EventsTableDTO>> GetEventsTablesAsync(CancellationToken cancellationToken = default);

    public Task<EventsTableDTO> DeleteEventsTableAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<EventsTableDTO> AddEventsTableAsync(EventsTableDTO eventsTableDTO);

    public Task<EventsTableDTO> UpdateEventsTableAsync(Guid id, EventsTableDTO eventsTableDTO);
}
