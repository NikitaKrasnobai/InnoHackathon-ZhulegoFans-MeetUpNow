using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class EventRepository : IEventRepository
{
    private readonly RepositoryDbContext _context;
    public EventRepository(RepositoryDbContext context)
    {
        _context = context;
    }
    public async Task<Event> AddEventAsync(Event events)
    {
        await _context.Events.AddAsync(events);
        await _context.SaveChangesAsync();

        return events;
    }

    public async Task DeleteEventAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var events = await _context.Events.FindAsync(id, cancellationToken);

        if (events is not null)
        {
            _context.Events.Remove(events);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<Event?> GetEventByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Events.FindAsync(id, cancellationToken);
    }

    public async Task<List<Event>> GetEventsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Events.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Event> UpdateEventAsync(Event events)
    {
        _context.Events.Update(events);
        await _context.SaveChangesAsync();

        return events;
    }
}
