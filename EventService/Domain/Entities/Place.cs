namespace Domain.Entities;

public class Place
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public Guid EventsTableId { get; set; }

    public Place() { }

    public Place(string name, string address)
    {
        Name = name;
        Address = address;
    }
}
