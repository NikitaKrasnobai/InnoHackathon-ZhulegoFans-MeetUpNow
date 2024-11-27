using Contract;
using Domain.Entities;

namespace Contract.Mapper
{
    public class PurposeMapper
    {
        public static PurposeDTO ToDto(Purpose purposeEntity)
        {
            if (purposeEntity == null) throw new ArgumentNullException(nameof(purposeEntity));

            return new PurposeDTO
            {
                Id = purposeEntity.Id,
                Name = purposeEntity.Name,
                Description = purposeEntity.Description,
                StartDate = purposeEntity.StartDate,
                EndDate = purposeEntity.EndDate,
                EventId = purposeEntity.EventId
            };
        }

        public static Purpose ToEntity(PurposeDTO purposeDto)
        {
            if (purposeDto == null) throw new ArgumentNullException(nameof(purposeDto));

            return new Purpose
            {
                Id = purposeDto.Id,
                Name = purposeDto.Name,
                Description = purposeDto.Description,
                StartDate = purposeDto.StartDate,
                EndDate = purposeDto.EndDate,
                EventId = purposeDto.EventId
            };
        }
    }
}