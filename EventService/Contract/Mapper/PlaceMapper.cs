using Contract;
using Domain.Entities;

namespace Contract.Mapper
{
    public class PlaceMapper
    {
        public static PlaceDTO ToDto(Place placeEntity)
        {
            if (placeEntity == null) throw new ArgumentNullException(nameof(placeEntity));

            return new PlaceDTO
            {
                Id = placeEntity.Id,
                Name = placeEntity.Name,
                Address = placeEntity.Address,
                EventsTableId = placeEntity.EventsTableId
            };
        }

        public static Place ToEntity(PlaceDTO placeDto)
        {
            if (placeDto == null) throw new ArgumentNullException(nameof(placeDto));

            return new Place
            {
                Id = placeDto.Id,
                Name = placeDto.Name,
                Address = placeDto.Address,
                EventsTableId = placeDto.EventsTableId
            };
        }
    }
}