namespace Contract;

public class EventsTableDTO
{
    public Guid Id { get; set; }

    public Guid EventId { get; set; }

    public Guid PlaceId { get; set; }

    public int CountOfVisits { get; set; }
}
