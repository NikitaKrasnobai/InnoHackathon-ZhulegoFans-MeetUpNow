using Contract;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/Documentation")]
public class DocumentationController : ControllerBase
{
    private readonly IDocumentationService _documentationService;

    public DocumentationController(IDocumentationService documentationService) => _documentationService = documentationService;

    [HttpPost]
    public async Task<ActionResult<DocumentationDTO>> AddDocumentationsAsync([FromBody] DocumentationDTO documentationDTO)
    {

        if (documentationDTO == null)
        {
            return BadRequest("Documentation data is required.");
        }

         await _documentationService.AddDocumentationsAsync(documentationDTO);

        return Created("", documentationDTO);
    }

    [HttpGet("{DocumentationId:guid}")]
    public async Task<ActionResult<DocumentationDTO>> GetDocumentationByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var documentation = await _documentationService.GetDocumentationByIdAsync(id, cancellationToken);

        if (documentation == null)
        {
            return NotFound();
        }

        return Ok(documentation);
    }

    [HttpDelete("{DocumentationId:guid}")]
    public async Task<IActionResult> DeleteDocumentationAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var deletedDocumentation = await _documentationService.DeleteDocumentationAsync(id, cancellationToken);
            return Ok(deletedDocumentation);
        }
        catch (DocumentationsNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<DocumentationDTO>>> GetDocumentationsAsync(CancellationToken cancellationToken = default)
    {
        var documentation = await _documentationService.GetDocumentationsAsync(cancellationToken);

        return Ok(documentation);
    }

    [HttpPut("{DocumentationId:guid}")]
    public async Task<ActionResult<DocumentationDTO>> UpdateDocumentationsAsync(Guid id, [FromBody] DocumentationDTO documentationDTO)
    {
        if (documentationDTO == null)
        {
            return BadRequest("Employee data is required.");
        }

        try
        {
            var updatedDocumentation = await _documentationService.UpdateDocumentationsAsync(id, documentationDTO);

            return Ok(updatedDocumentation);
        }
        catch (DocumentationsNotFoundException)
        {
            return NotFound();
        }
    }
}
