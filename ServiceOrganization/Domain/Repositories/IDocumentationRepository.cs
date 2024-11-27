using Domain.Entities;

namespace Domain.Repositories;

public interface IDocumentationRepository
{
    public Task<Documentation?> GetDocumentationByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<Documentation>> GetDocumentationsAsync(CancellationToken cancellationToken = default);

    public Task DeleteDocumentationAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<Documentation> AddDocumentationsAsync(Documentation documentations);

    public Task<Documentation> UpdateDocumentationsAsync(Documentation documentations);
}
