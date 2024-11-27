using Domain.Entities;

namespace Contract.Mapper;

public class DocumentationMapper
{
    public static DocumentationDTO ToDto(Documentation documentation)
    {
        if (documentation == null) throw new ArgumentNullException(nameof(documentation));

        return new DocumentationDTO
        {
            Id = documentation.Id,
            EmployeesId = documentation.EmployeesId,
            DateTime = documentation.DateTime
        };
    }

    public static Documentation ToEntity(DocumentationDTO documentationDto)
    {
        if (documentationDto == null) throw new ArgumentNullException(nameof(documentationDto));

        return new Documentation
        {
            Id = documentationDto.Id,
            EmployeesId = documentationDto.EmployeesId,
            DateTime = documentationDto.DateTime
        };
    }
}
