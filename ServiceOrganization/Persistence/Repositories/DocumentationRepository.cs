using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class DocumentationRepository : IDocumentationRepository
{
    private readonly RepositoryDbContext _context;
    public DocumentationRepository(RepositoryDbContext context)
    {
        _context = context;
    }

    public async Task<Documentation> AddDocumentationsAsync(Documentation documentations)
    {
        await _context.Documentations.AddAsync(documentations);
        await _context.SaveChangesAsync();

        return documentations;
    }

    public async Task DeleteDocumentationAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentations = await _context.Documentations.FindAsync(id, cancellationToken);

        if (documentations is not null)
        {
            _context.Documentations.Remove(documentations);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<Documentation?> GetDocumentationByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Documentations.FindAsync(id, cancellationToken);
    }

    public async Task<List<Documentation>> GetDocumentationsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Documentations.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Documentation> UpdateDocumentationsAsync(Documentation documentations)
    {
        _context.Documentations.Update(documentations);
        await _context.SaveChangesAsync();

        return documentations;
    }
}
