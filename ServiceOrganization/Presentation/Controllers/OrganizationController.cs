using Contract;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/Organization")]
public class OrganizationController : ControllerBase
{
    private readonly IOrganizationService _organizationService;

    public OrganizationController(IOrganizationService organizationService) => _organizationService = organizationService;

    [HttpPost]
    public async Task<ActionResult<OrganizationDTO>> AddOrganizationsAsync([FromBody] OrganizationDTO organizationDTO)
    {

        if (organizationDTO == null)
        {
            return BadRequest("Organization data is required.");
        }

        await _organizationService.AddOrganizationsAsync(organizationDTO);

        return Created("", organizationDTO);
    }

    [HttpGet("{OrganizationId:guid}")]
    public async Task<ActionResult<OrganizationDTO>> GetOrganizationByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var organization = await _organizationService.GetOrganizationByIdAsync(id, cancellationToken);

        if (organization == null)
        {
            return NotFound();
        }

        return Ok(organization);
    }

    [HttpDelete("{OrganizationId:guid}")]
    public async Task<IActionResult> DeleteOrganizationsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var deletedOrganization = await _organizationService.DeleteOrganizationsAsync(id, cancellationToken);

            return Ok(deletedOrganization);
        }
        catch (OrganizationsNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<OrganizationDTO>>> GetOrganizationsAsync(CancellationToken cancellationToken = default)
    {
        var organization = await _organizationService.GetOrganizationsAsync(cancellationToken);

        return Ok(organization);
    }

    [HttpPut("{OrganizationId:guid}")]
    public async Task<ActionResult<OrganizationDTO>> UpdateOrganizationsAsync(Guid id, [FromBody] OrganizationDTO organizationDTO)
    {
        if (organizationDTO == null)
        {
            return BadRequest("Organization data is required.");
        }

        try
        {
            var updatedOrganization = await _organizationService.UpdateOrganizationsAsync(id, organizationDTO);

            return Ok(updatedOrganization);
        }
        catch (OrganizationsNotFoundException)
        {
            return NotFound();
        }
    }
}
