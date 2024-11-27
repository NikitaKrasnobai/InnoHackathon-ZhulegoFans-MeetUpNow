using Contract;

namespace Services.Abstractions;

public interface IEventService
{
    public Task<EventDTO?> GetEventByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<EventDTO>> GetEventsAsync(CancellationToken cancellationToken = default);

    public Task<EventDTO> DeleteEventAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<EventDTO> AddEventAsync(EventDTO eventDTO);

    public Task<EventDTO> UpdateEventAsync(Guid id, EventDTO eventDTO);
}
