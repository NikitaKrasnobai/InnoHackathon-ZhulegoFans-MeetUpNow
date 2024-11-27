using Contract;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/EventsTables")]
public class EventsTablesController : ControllerBase
{
    private readonly IEventsTableService _eventsTableService;

    public EventsTablesController(IEventsTableService eventsTableService) => _eventsTableService = eventsTableService;

    [HttpPost]
    public async Task<ActionResult<EventsTableDTO>> AddEventsTableAsync([FromBody] EventsTableDTO eventsTableDTO)
    {
        if (eventsTableDTO is null)
        {
            return BadRequest("EventsTable data is required.");
        }

        await _eventsTableService.AddEventsTableAsync(eventsTableDTO);

        return Created("", eventsTableDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventsTableDTO>> GetEventsTableByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var eventsTable = await _eventsTableService.GetEventsTableByIdAsync(id, cancellationToken);

        if (eventsTable == null)
        {
            return NotFound();
        }

        return Ok(eventsTable);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEventsTableAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var deletedEventsTable = await _eventsTableService.DeleteEventsTableAsync(id, cancellationToken);
            return Ok(deletedEventsTable);
        }
        catch (EventsTableNotFoundException)
        {
            return NotFound();
        }
    }
    [HttpGet]
    public async Task<ActionResult<List<EventsTableDTO>>> GetEventsTableAsync(CancellationToken cancellationToken = default)
    {
        var eventsTable = await _eventsTableService.GetEventsTablesAsync(cancellationToken);

        return Ok(eventsTable);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<EventsTableDTO>> UpdateEventsTableAsync(Guid id, [FromBody] EventsTableDTO eventsTableDTO)
    {

        if (eventsTableDTO is null)
        {
            return BadRequest("EventsTable data is required and ID must match.");
        }

        try
        {
            var updatedEventsTable = await _eventsTableService.UpdateEventsTableAsync(id, eventsTableDTO);

            return Ok(updatedEventsTable);
        }
        catch (EventsTableNotFoundException)
        {
            return NotFound();
        }
    }
}
