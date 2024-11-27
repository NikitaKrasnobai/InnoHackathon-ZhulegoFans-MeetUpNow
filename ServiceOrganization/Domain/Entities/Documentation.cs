namespace Domain.Entities;

public class Documentation
{
    public Guid Id { get; set; } 

    public Guid EmployeesId { get; set; }

    public DateTime DateTime { get; set; }

    public ICollection<Employee>? Employees { get; set; }
 
    public Documentation() { }

    public Documentation(DateTime dateTime, ICollection<Employee>? employees)
    {
        DateTime = dateTime;
        Employees = employees;
    }
}
