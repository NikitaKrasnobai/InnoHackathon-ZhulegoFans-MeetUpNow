using Contract;
using Domain.Entities;

namespace Services.Abstractions;

public interface IOrganizationService
{
    public Task<OrganizationDTO?> GetOrganizationByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<OrganizationDTO>> GetOrganizationsAsync(CancellationToken cancellationToken = default);

    public Task<OrganizationDTO?> DeleteOrganizationsAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<OrganizationDTO> AddOrganizationsAsync(OrganizationDTO organizationsDTO);

    public Task<OrganizationDTO> UpdateOrganizationsAsync(Guid id, OrganizationDTO organizationsDTO);
}
