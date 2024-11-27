using Contract;
using Contract.Mapper;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstractions;

namespace Service;

public class DocumentationService : IDocumentationService
{
    private readonly IDocumentationRepository _documentationRepository;

    public DocumentationService(IDocumentationRepository documentationRepository)
    {
        _documentationRepository = documentationRepository;
    }

    public async Task<DocumentationDTO> AddDocumentationsAsync(DocumentationDTO documentationsDTO)
    {
        return DocumentationMapper.ToDto(await _documentationRepository.AddDocumentationsAsync(DocumentationMapper.ToEntity(documentationsDTO)));
    }

    public async Task<DocumentationDTO?> DeleteDocumentationAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentation = await _documentationRepository.GetDocumentationByIdAsync(id, cancellationToken);

        if (documentation == null)
        {
            throw new DocumentationsNotFoundException(id);
        }
        await _documentationRepository.DeleteDocumentationAsync(id, cancellationToken);

        return DocumentationMapper.ToDto(documentation);
    }

    public async Task<DocumentationDTO?> GetDocumentationByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentation = await _documentationRepository.GetDocumentationByIdAsync(id, cancellationToken);

        if (documentation == null)
        {
            throw new OrganizationsNotFoundException(id);
        }

        return DocumentationMapper.ToDto(documentation);
    }

    public async Task<List<DocumentationDTO>> GetDocumentationsAsync(CancellationToken cancellationToken = default)
    {
        var documentation = await _documentationRepository.GetDocumentationsAsync(cancellationToken);

        return documentation.Select(DocumentationMapper.ToDto).ToList();
    }

    public async Task<DocumentationDTO> UpdateDocumentationsAsync(Guid id, DocumentationDTO documentationsDTO)
    {
        var result = await _documentationRepository.GetDocumentationByIdAsync(id);

        if (result == null)
        {
            throw new KeyNotFoundException($"Documentation with ID {id} not found.");
        }

        result.DateTime = documentationsDTO.DateTime;

        return DocumentationMapper.ToDto(await _documentationRepository.UpdateDocumentationsAsync(result));
    }
}
