using Contract;
using Contract.Mapper;
using Domain.Repositories;
using Services.Abstractions;

namespace Service;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    public async Task<EventDTO> AddEventAsync(EventDTO eventDTO)
    {
        return EventMapper.ToDto(await _eventRepository.AddEventAsync(EventMapper.ToEntity(eventDTO)));
    }

    public async Task<EventDTO> DeleteEventAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var eventEntity = await _eventRepository.GetEventByIdAsync(id, cancellationToken);

        if (eventEntity is null)
        {
            throw new EventNotFoundException(id);
        }
        await _eventRepository.DeleteEventAsync(id, cancellationToken);

        return EventMapper.ToDto(eventEntity);
    }

    public async Task<EventDTO?> GetEventByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var eventEntity = await _eventRepository.GetEventByIdAsync(id, cancellationToken);

        if (eventEntity is null)
        {
            throw new EventNotFoundException(id);
        }

        return EventMapper.ToDto(eventEntity);
    }

    public async Task<List<EventDTO>> GetEventsAsync(CancellationToken cancellationToken = default)
    {
        var eventEntity = await _eventRepository.GetEventsAsync(cancellationToken);

        return eventEntity.Select(EventMapper.ToDto).ToList();
    }

    public async Task<EventDTO> UpdateEventAsync(Guid id, EventDTO eventDTO)
    {
        var result = await _eventRepository.GetEventByIdAsync(id);

        if (result == null)
        {
            throw new KeyNotFoundException($"Event with ID {id} not found.");
        }

        result.Description = eventDTO.Description;
        result.Time = eventDTO.Time;
        result.Name = eventDTO.Name;   
        result.EmailAddress = eventDTO.EmailAddress;

        return EventMapper.ToDto(await _eventRepository.UpdateEventAsync(result));
    }
}
