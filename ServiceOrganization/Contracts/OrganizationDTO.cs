using Domain.Entities;

namespace Contract;

public class OrganizationDTO
{
    public Guid Id { get; set; } 

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
}
