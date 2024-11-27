public sealed class EventsTableDoesNotBelongToEventException : BadRequestException
{
    public EventsTableDoesNotBelongToEventException(Guid eventId, Guid eventsTableId)
        : base($"The events table with the identifier {eventsTableId} does not belong to the event with the identifier {eventId}")
    {
    }
}