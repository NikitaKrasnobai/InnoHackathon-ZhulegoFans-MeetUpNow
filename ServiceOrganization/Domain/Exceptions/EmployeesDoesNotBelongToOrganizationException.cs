namespace Domain.Exceptions;

public sealed class EmployeesDoesNotBelongToOrganizationException : BadRequestException
{
    public EmployeesDoesNotBelongToOrganizationException(Guid Id, Guid EmployeesIdId)
       : base($"The organization with the identifier {Id} does not belong to the employees with the identifier {EmployeesIdId}")
    {
    }
}
