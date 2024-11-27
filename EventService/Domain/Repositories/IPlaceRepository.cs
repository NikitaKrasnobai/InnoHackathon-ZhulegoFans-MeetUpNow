using Domain.Entities;

namespace Domain.Repositories;

public interface IPlaceRepository
{
    public Task<Place?> GetPlaceByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<Place>> GetPlacesAsync(CancellationToken cancellationToken = default);

    public Task DeletePlaceAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<Place> AddPlaceAsync(Place place);

    public Task<Place> UpdatePlaceAsync(Place place);
}
