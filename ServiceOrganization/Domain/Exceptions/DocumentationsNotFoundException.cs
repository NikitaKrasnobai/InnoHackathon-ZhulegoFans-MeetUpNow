namespace Domain.Exceptions;

public sealed class DocumentationsNotFoundException : NotFoundException
{
    public DocumentationsNotFoundException(Guid Id)
            : base($"The Documentations with the identifier {Id} was not found.")
    {
    }
}
