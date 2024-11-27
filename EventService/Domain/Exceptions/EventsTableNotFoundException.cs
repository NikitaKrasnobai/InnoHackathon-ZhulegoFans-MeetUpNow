public sealed class EventsTableNotFoundException : NotFoundException
{
    public EventsTableNotFoundException(Guid eventsTableId)
        : base($"The eventsTable with the identifier {eventsTableId} was not found.")
    {
    }
}