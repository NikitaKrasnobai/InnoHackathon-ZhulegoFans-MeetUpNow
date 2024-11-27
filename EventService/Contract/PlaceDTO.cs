namespace Contract;

public class PlaceDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public Guid EventsTableId { get; set; }
}
