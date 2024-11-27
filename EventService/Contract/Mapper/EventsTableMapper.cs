using Contract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Contract.Mapper
{
    public class EventsTableMapper
    {
        public static EventsTableDTO ToDto(EventsTable eventsTableEntity)
        {
            if (eventsTableEntity == null) throw new ArgumentNullException(nameof(eventsTableEntity));

            return new EventsTableDTO
            {
                Id = eventsTableEntity.Id,
                EventId = eventsTableEntity.EventId,
                PlaceId = eventsTableEntity.PlaceId,
                CountOfVisits = eventsTableEntity.CountOfVisits
            };
        }

        public static EventsTable ToEntity(EventsTableDTO eventsTableDto)
        {
            if (eventsTableDto == null) throw new ArgumentNullException(nameof(eventsTableDto));

            return new EventsTable
            {
                Id = eventsTableDto.Id,
                EventId = eventsTableDto.EventId,
                PlaceId = eventsTableDto.PlaceId,
                CountOfVisits = eventsTableDto.CountOfVisits
            };
        }
    }
}