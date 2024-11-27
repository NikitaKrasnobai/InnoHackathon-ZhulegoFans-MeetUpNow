namespace Domain.Entities;

public class Organization
{
    public Guid Id { get; set; } 

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public ICollection<Employee>? Employees { get; set; }

    public Organization() { }

    public Organization(string name, string address)
    {
        Name = name;
        Address = address;
    }
}
