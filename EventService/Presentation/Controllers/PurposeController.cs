using Contract;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/Purposes")]
public class PurposeController : ControllerBase
{
    private readonly IPurposeService _purposeService;

    public PurposeController(IPurposeService purposeService) => _purposeService = purposeService;

    [HttpPost]
    public async Task<ActionResult<PurposeDTO>> AddPurposeAsync([FromBody] PurposeDTO purposeDTO)
    {
        if (purposeDTO is null)
        {
            return BadRequest("Purpose data is required.");
        }

        await _purposeService.AddPurposeAsync(purposeDTO);

        return Created("", purposeDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PurposeDTO>> GetPurposeByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var purpose = await _purposeService.GetPurposeByIdAsync(id, cancellationToken);

        if (purpose == null)
        {
            return NotFound();
        }

        return Ok(purpose);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePurposeAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var deletedPurpose = await _purposeService.DeletePurposeAsync(id, cancellationToken);
            return Ok(deletedPurpose);
        }
        catch (PurposeNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<PurposeDTO>>> GetPurposeAsync(CancellationToken cancellationToken = default)
    {
        var purpose = await _purposeService.GetPurposesAsync(cancellationToken);

        return Ok(purpose);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PurposeDTO>> UpdatePurposeAsync(Guid id, [FromBody] PurposeDTO purposeDTO)
    {

        if (purposeDTO is null)
        {
            return BadRequest("Purpose data is required and ID must match.");
        }

        try
        {
            var updatedPurpose = await _purposeService.UpdatePurposeAsync(id, purposeDTO);

            return Ok(updatedPurpose);
        }
        catch (PurposeNotFoundException)
        {
            return NotFound();
        }
    }
}
