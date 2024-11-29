namespace Domain.Entities;

public class Event
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string? Time { get; set; }

    public string EmailAddress { get; set; } = string.Empty;

    public ICollection<Purpose>? Purposes { get; set; }

    public ICollection<EventsTable>? EventsTables { get; set; }

    public Event() { }

    public Event(string name, string description, string? time, string emailAddress)
    {
        Name = name;
        Description = description;
        Time = time;
        EmailAddress = emailAddress;
    }
}

