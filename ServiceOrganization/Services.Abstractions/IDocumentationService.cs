using Contract;
using Domain.Entities;

namespace Services.Abstractions;

public interface IDocumentationService
{
    public Task<DocumentationDTO?> GetDocumentationByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<DocumentationDTO>> GetDocumentationsAsync(CancellationToken cancellationToken = default);

    public Task<DocumentationDTO?> DeleteDocumentationAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<DocumentationDTO> AddDocumentationsAsync(DocumentationDTO documentationsDTO);

    public Task<DocumentationDTO> UpdateDocumentationsAsync(Guid id, DocumentationDTO documentationsDTO);
}
