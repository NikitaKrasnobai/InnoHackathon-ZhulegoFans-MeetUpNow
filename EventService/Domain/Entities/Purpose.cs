namespace Domain.Entities;

public class Purpose
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Guid EventId { get; set; }

    public Purpose() { }

    public Purpose(string name, string description, DateTime startDate, DateTime endDate)
    {
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
    }
}
