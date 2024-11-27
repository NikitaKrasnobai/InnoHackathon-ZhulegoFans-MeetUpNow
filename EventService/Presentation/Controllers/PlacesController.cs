using Contract;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/Places")]
public class PlacesController : ControllerBase
{
    private readonly IPlaceService _placeService;

    public PlacesController(IPlaceService placeService) => _placeService = placeService;

    [HttpPost]
    public async Task<ActionResult<PlaceDTO>> AddPlaceAsync([FromBody] PlaceDTO placeDTO)
    {
        if (placeDTO is null)
        {
            return BadRequest("Place data is required.");
        }

        await _placeService.AddPlaceAsync(placeDTO);

        return Created("", placeDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlaceDTO>> GetPlaceByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var place = await _placeService.GetPlaceByIdAsync(id, cancellationToken);

        if (place == null)
        {
            return NotFound();
        }

        return Ok(place);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlaceAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var deletedPlace = await _placeService.DeletePlaceAsync(id, cancellationToken);
            return Ok(deletedPlace);
        }
        catch (PlaceNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<PlaceDTO>>> GetPlaceAsync(CancellationToken cancellationToken = default)
    {
        var place = await _placeService.GetPlacesAsync(cancellationToken);

        return Ok(place);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlaceDTO>> UpdatePlaceAsync(Guid id, [FromBody] PlaceDTO placeDTO)
    {

        if (placeDTO is null)
        {
            return BadRequest("Place data is required and ID must match.");
        }

        try
        {
            var updatedPlace = await _placeService.UpdatePlaceAsync(id, placeDTO);

            return Ok(updatedPlace);
        }
        catch (PlaceNotFoundException)
        {
            return NotFound();
        }
    }
}
