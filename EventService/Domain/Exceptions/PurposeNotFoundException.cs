public sealed class PurposeNotFoundException : NotFoundException
{
    public PurposeNotFoundException(Guid purposeId)
        : base($"The purpose with the identifier {purposeId} was not found.")
    {
    }
}