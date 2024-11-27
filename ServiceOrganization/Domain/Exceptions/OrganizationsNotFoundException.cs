namespace Domain.Exceptions;

public sealed class OrganizationsNotFoundException : NotFoundException
{
    public OrganizationsNotFoundException(Guid Id)
              : base($"The Organizations with the identifier {Id} was not found.")
    {
    }
}
