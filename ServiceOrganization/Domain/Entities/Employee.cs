using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }

    public Guid OrganizationId { get; set; } 

    public string FirstName { get; set; } = string.Empty;

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public Organization Organization { get; set; } = null!;

    public ICollection<Documentation>? Documentations { get; set; }

    public Employee() { }

    public Employee(string firstName, string? middleName, string? lastName, string email, string phoneNumber)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}
