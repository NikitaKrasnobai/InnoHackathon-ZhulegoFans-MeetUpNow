using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.ContextDB;

namespace Persistence.Repositories;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly RepositoryDbContext _context;
    public OrganizationRepository(RepositoryDbContext context)
    {
        _context = context;
    }
    public async Task<Organization> AddOrganizationsAsync(Organization organizations)
    {
        await _context.Organizations.AddAsync(organizations);
        await _context.SaveChangesAsync();

        return organizations;
    }

    public async Task DeleteOrganizationsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var organizations = await _context.Organizations.FindAsync(id, cancellationToken);

        if (organizations is not null)
        {
            _context.Organizations.Remove(organizations);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<Organization?> GetOrganizationByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Organizations.FindAsync(id, cancellationToken);
    }

    public async Task<List<Organization>> GetOrganizationsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Organizations.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Organization> UpdateOrganizationsAsync(Organization organizations)
    {
        _context.Organizations.Update(organizations);
        await _context.SaveChangesAsync();

        return organizations;
    }
}
