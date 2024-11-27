public sealed class PlaceDoesNotBelongToEventException : BadRequestException
{
    public PlaceDoesNotBelongToEventException(Guid eventId, Guid placeId)
        : base($"The place with the identifier {placeId} does not belong to the event with the identifier {eventId}")
    {
    }
}