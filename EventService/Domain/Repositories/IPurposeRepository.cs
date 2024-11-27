using Domain.Entities;

namespace Domain.Repositories;

public interface IPurposeRepository
{
    public Task<Purpose?> GetPurposeByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<Purpose>> GetPurposesAsync(CancellationToken cancellationToken = default);

    public Task DeletePurposeAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<Purpose> AddPurposeAsync(Purpose purpose);

    public Task<Purpose> UpdatePurposeAsync(Purpose purpose);
}
