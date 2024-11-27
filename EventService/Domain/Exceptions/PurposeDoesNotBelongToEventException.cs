public sealed class PurposeDoesNotBelongToEventException : BadRequestException
{
    public PurposeDoesNotBelongToEventException(Guid eventId, Guid purposeId)
        : base($"The purpose with the identifier {purposeId} does not belong to the event with the identifier {eventId}")
    {
    }
}
