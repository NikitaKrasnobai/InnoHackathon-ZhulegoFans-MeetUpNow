using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Persistence.Repositories;

public class EventsTableRepository : IEventsTableRepository
{
    private readonly RepositoryDbContext _context;
    public EventsTableRepository(RepositoryDbContext context)
    {
        _context = context;
    }
    public async Task<EventsTable> AddEventsTableAsync(EventsTable eventsTable)
    {
        await _context.EventsTables.AddAsync(eventsTable);
        await _context.SaveChangesAsync();

        return eventsTable;
    }

    public async Task DeleteEventsTableAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var eventsTable = await _context.EventsTables.FindAsync(id, cancellationToken);

        if (eventsTable is not null)
        {
            _context.EventsTables.Remove(eventsTable);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<EventsTable?> GetEventsTableByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.EventsTables.FindAsync(id, cancellationToken);
    }

    public async Task<List<EventsTable>> GetEventsTablesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.EventsTables.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<EventsTable> UpdateEventsTableAsync(EventsTable eventsTable)
    {
        _context.EventsTables.Update(eventsTable);
        await _context.SaveChangesAsync();

        return eventsTable;
    }
}
