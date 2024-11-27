using Contract;
using Domain.Entities;

namespace Contract.Mapper
{
    public class EventMapper
    {
        public static EventDTO ToDto(Event eventEntity)
        {
            if (eventEntity == null) throw new ArgumentNullException(nameof(eventEntity));

            return new EventDTO
            {
                Id = eventEntity.Id,
                Name = eventEntity.Name,
                Description = eventEntity.Description,
                Time = eventEntity.Time
            };
        }

        public static Event ToEntity(EventDTO eventDto)
        {
            if (eventDto == null) throw new ArgumentNullException(nameof(eventDto));

            return new Event
            {
                Name = eventDto.Name,
                Description = eventDto.Description,
                Time = eventDto.Time
            };
        }
    }
}