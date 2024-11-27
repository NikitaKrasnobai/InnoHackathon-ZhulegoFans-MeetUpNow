namespace Domain.Exceptions;

public sealed class EmployeesNotFoundException : NotFoundException
{
    public EmployeesNotFoundException(Guid Id)
            : base($"The Employees with the identifier {Id} was not found.")
    {
    }
}
