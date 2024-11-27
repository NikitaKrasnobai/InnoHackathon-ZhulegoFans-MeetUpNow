using Contract;

namespace Services.Abstractions;

public interface IPurposeService
{
    public Task<PurposeDTO?> GetPurposeByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<PurposeDTO>> GetPurposesAsync(CancellationToken cancellationToken = default);

    public Task<PurposeDTO> DeletePurposeAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<PurposeDTO> AddPurposeAsync(PurposeDTO purposeDTO);

    public Task<PurposeDTO> UpdatePurposeAsync(Guid id, PurposeDTO purposeDTO);
}
