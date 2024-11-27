using Contract;
using Contract.Mapper;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Services.Abstractions;

namespace Service
{
    public class EventsTableService : IEventsTableService
    {
        private readonly IEventsTableRepository _eventsTableRepository;

        public EventsTableService(IEventsTableRepository eventsTableRepository)
        {
            _eventsTableRepository = eventsTableRepository;
        }
        public async Task<EventsTableDTO> AddEventsTableAsync(EventsTableDTO eventsTableDTO)
        {
            return EventsTableMapper.ToDto(await _eventsTableRepository.AddEventsTableAsync(EventsTableMapper.ToEntity(eventsTableDTO)));
        }

        public async Task<EventsTableDTO> DeleteEventsTableAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var eventsTable = await _eventsTableRepository.GetEventsTableByIdAsync(id, cancellationToken);

            if (eventsTable is null)
            {
                throw new EventNotFoundException(id);
            }
            await _eventsTableRepository.DeleteEventsTableAsync(id, cancellationToken);

            return EventsTableMapper.ToDto(eventsTable);
        }

        public async Task<EventsTableDTO?> GetEventsTableByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var eventsTable = await _eventsTableRepository.GetEventsTableByIdAsync(id, cancellationToken);

            if (eventsTable is null)
            {
                throw new EventNotFoundException(id);
            }

            return EventsTableMapper.ToDto(eventsTable);
        }

        public async Task<List<EventsTableDTO>> GetEventsTablesAsync(CancellationToken cancellationToken = default)
        {
            var eventsTable = await _eventsTableRepository.GetEventsTablesAsync(cancellationToken);

            return eventsTable.Select(EventsTableMapper.ToDto).ToList();
        }

        public async Task<EventsTableDTO> UpdateEventsTableAsync(Guid id, EventsTableDTO eventsTableDTO)
        {
            var result = await _eventsTableRepository.GetEventsTableByIdAsync(id);

            if (result == null)
            {
                throw new KeyNotFoundException($"EventsTable with ID {id} not found.");
            }

            result.CountOfVisits = eventsTableDTO.CountOfVisits;

            return EventsTableMapper.ToDto(await _eventsTableRepository.UpdateEventsTableAsync(result));
        }
    }
}
