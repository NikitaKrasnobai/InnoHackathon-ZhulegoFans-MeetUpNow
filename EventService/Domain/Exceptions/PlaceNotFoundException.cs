public sealed class PlaceNotFoundException : NotFoundException
{
    public PlaceNotFoundException(Guid placeId)
        : base($"The place with the identifier {placeId} was not found.")
    {
    }
}