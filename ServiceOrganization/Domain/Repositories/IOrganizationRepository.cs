using Domain.Entities;

namespace Domain.Repositories;

public interface IOrganizationRepository
{
    public Task<Organization?> GetOrganizationByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<Organization>> GetOrganizationsAsync(CancellationToken cancellationToken = default);

    public Task DeleteOrganizationsAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<Organization> AddOrganizationsAsync(Organization organizations);

    public Task<Organization> UpdateOrganizationsAsync(Organization organizations);
}
