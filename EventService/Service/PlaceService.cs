using Contract;
using Contract.Mapper;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Services.Abstractions;

namespace Service;

public class PlaceService : IPlaceService
{
    private readonly IPlaceRepository _placeRepository;

    public PlaceService(IPlaceRepository placeRepository)
    {
        _placeRepository = placeRepository;
    }
    public async Task<PlaceDTO> AddPlaceAsync(PlaceDTO placeDTO)
    {
        return PlaceMapper.ToDto(await _placeRepository.AddPlaceAsync(PlaceMapper.ToEntity(placeDTO)));
    }

    public async Task<PlaceDTO> DeletePlaceAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var place = await _placeRepository.GetPlaceByIdAsync(id, cancellationToken);

        if (place is null)
        {
            throw new PlaceNotFoundException(id);
        }
        await _placeRepository.DeletePlaceAsync(id, cancellationToken);

        return PlaceMapper.ToDto(place);
    }

    public async Task<PlaceDTO?> GetPlaceByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var place = await _placeRepository.GetPlaceByIdAsync(id, cancellationToken);

        if (place is null)
        {
            throw new PlaceNotFoundException(id);
        }

        return PlaceMapper.ToDto(place);
    }

    public async Task<List<PlaceDTO>> GetPlacesAsync(CancellationToken cancellationToken = default)
    {
        var place = await _placeRepository.GetPlacesAsync(cancellationToken);

        return place.Select(PlaceMapper.ToDto).ToList();
    }

    public async Task<PlaceDTO> UpdatePlaceAsync(Guid id, PlaceDTO placeDTO)
    {
        var result = await _placeRepository.GetPlaceByIdAsync(id);

        if (result == null)
        {
            throw new KeyNotFoundException($"Place with ID {id} not found.");
        }
        
        result.Name = placeDTO.Name;
        result.Address = placeDTO.Address;

        return PlaceMapper.ToDto(await _placeRepository.UpdatePlaceAsync(result));
    }
}
