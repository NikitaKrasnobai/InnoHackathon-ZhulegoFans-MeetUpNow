public sealed class EventNotFoundException : NotFoundException
{
    public EventNotFoundException(Guid eventId)
        : base($"The event with the identifier {eventId} was not found.")
    {
    }
}