using Contract;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
namespace Presentation.Controllers;

[ApiController]
[Route("/api/Events")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService) => _eventService = eventService;

    [HttpPost]
    public async Task<ActionResult<EventDTO>> AddEventAsync([FromBody] EventDTO eventDTO)
    {
        if (eventDTO is null)
        {
            return BadRequest("Event data is required.");
        }

        await _eventService.AddEventAsync(eventDTO);

        return Created("", eventDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventDTO>> GetEventByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var events = await _eventService.GetEventByIdAsync(id, cancellationToken);

        if (events == null)
        {
            return NotFound();
        }

        return Ok(events);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEventAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var deletedEvent = await _eventService.DeleteEventAsync(id, cancellationToken);
            return Ok(deletedEvent);
        }
        catch (EventNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<EventDTO>>> GetEventAsync(CancellationToken cancellationToken = default)
    {
        var events = await _eventService.GetEventsAsync(cancellationToken);

        return Ok(events);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EventDTO>> UpdateEventAsync(Guid id, [FromBody] EventDTO eventDTO)
    {

        if (eventDTO is null)
        {
            return BadRequest("Event data is required and ID must match.");
        }

        try
        {
            var updatedEvent = await _eventService.UpdateEventAsync(id, eventDTO);

            return Ok(updatedEvent);
        }
        catch (EventNotFoundException)
        {
            return NotFound();
        }
    }
}
