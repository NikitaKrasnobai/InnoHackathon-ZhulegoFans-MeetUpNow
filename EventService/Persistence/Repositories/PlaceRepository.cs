using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Persistence.Repositories;

public class PlaceRepository : IPlaceRepository
{

    private readonly RepositoryDbContext _context;
    public PlaceRepository(RepositoryDbContext context)
    {
        _context = context;
    }
    public async Task<Place> AddPlaceAsync(Place place)
    {
        await _context.Places.AddAsync(place);
        await _context.SaveChangesAsync();

        return place;
    }

    public async Task DeletePlaceAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var place = await _context.Places.FindAsync(id, cancellationToken);

        if (place is not null)
        {
            _context.Places.Remove(place);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<Place?> GetPlaceByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Places.FindAsync(id, cancellationToken);
    }

    public async Task<List<Place>> GetPlacesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Places.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Place> UpdatePlaceAsync(Place place)
    {
        _context.Places.Update(place);
        await _context.SaveChangesAsync();

        return place;
    }
}
