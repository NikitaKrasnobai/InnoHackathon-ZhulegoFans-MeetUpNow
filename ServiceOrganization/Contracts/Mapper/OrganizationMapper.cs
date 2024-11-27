using Domain.Entities;

namespace Contract.Mapper;

public class OrganizationMapper
{
    public static OrganizationDTO ToDto(Organization organization)
    {
        if (organization == null) throw new ArgumentNullException(nameof(organization));

        return new OrganizationDTO
        {
            Id = organization.Id,
            Name = organization.Name,
            Address = organization.Address
        };
    }

    public static Organization ToEntity(OrganizationDTO organizationDto)
    {
        if (organizationDto == null) throw new ArgumentNullException(nameof(organizationDto));

        return new Organization
        {
            Id = organizationDto.Id,
            Name = organizationDto.Name,
            Address = organizationDto.Address
        };
    }
}
