using Contract;

namespace Services.Abstractions;

public interface IPlaceService
{
    public Task<PlaceDTO?> GetPlaceByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<PlaceDTO>> GetPlacesAsync(CancellationToken cancellationToken = default);

    public Task<PlaceDTO> DeletePlaceAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<PlaceDTO> AddPlaceAsync(PlaceDTO placeDTO);

    public Task<PlaceDTO> UpdatePlaceAsync(Guid id, PlaceDTO placeDTO);
}
