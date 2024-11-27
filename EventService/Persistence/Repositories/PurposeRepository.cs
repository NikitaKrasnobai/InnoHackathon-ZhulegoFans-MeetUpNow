using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class PurposeRepository : IPurposeRepository
{

    private readonly RepositoryDbContext _context;
    public PurposeRepository(RepositoryDbContext context)
    {
        _context = context;
    }
    public async Task<Purpose> AddPurposeAsync(Purpose purpose)
    {
        await _context.Purposes.AddAsync(purpose);
        await _context.SaveChangesAsync();

        return purpose;
    }

    public async Task DeletePurposeAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var purpose = await _context.Purposes.FindAsync(id, cancellationToken);

        if (purpose is not null)
        {
            _context.Purposes.Remove(purpose);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<Purpose?> GetPurposeByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Purposes.FindAsync(id, cancellationToken);
    }

    public async Task<List<Purpose>> GetPurposesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Purposes.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Purpose> UpdatePurposeAsync(Purpose purpose)
    {
        _context.Purposes.Update(purpose);
        await _context.SaveChangesAsync();

        return purpose;
    }
}
