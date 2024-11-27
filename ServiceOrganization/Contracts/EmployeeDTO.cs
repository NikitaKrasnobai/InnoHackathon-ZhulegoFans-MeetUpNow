namespace Contract;

public class EmployeeDTO
{
    public Guid Id { get; set; } 

    public Guid OrganizationId { get; set; } 

    public string FirstName { get; set; } = string.Empty;

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

}
