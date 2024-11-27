using Domain.Entities;

namespace Contract;

public class DocumentationDTO
{
    public Guid Id { get; set; }

    public Guid EmployeesId { get; set; } 

    public DateTime DateTime { get; set; }
}
