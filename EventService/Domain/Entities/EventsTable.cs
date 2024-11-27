namespace Domain.Entities;
public class EventsTable
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid EventId { get; set; }

    public Guid PlaceId { get; set; }

    public int CountOfVisits { get; set; }

    public EventsTable() { }

    public EventsTable(int countOfVisits, string description)
    {
        CountOfVisits = countOfVisits;
    }
}
