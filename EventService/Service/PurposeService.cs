using Contract;
using Contract.Mapper;
using Domain.Repositories;
using Services.Abstractions;

namespace Service;

public class PurposeService : IPurposeService
{
    private readonly IPurposeRepository _purposeRepository;

    public PurposeService(IPurposeRepository purposeRepository)
    {
        _purposeRepository = purposeRepository;
    }
    public async Task<PurposeDTO> AddPurposeAsync(PurposeDTO purposeDTO)
    {
        return PurposeMapper.ToDto(await _purposeRepository.AddPurposeAsync(PurposeMapper.ToEntity(purposeDTO)));
    }

    public async Task<PurposeDTO> DeletePurposeAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var purpose = await _purposeRepository.GetPurposeByIdAsync(id, cancellationToken);

        if (purpose is null)
        {
            throw new PurposeNotFoundException(id);
        }
        await _purposeRepository.DeletePurposeAsync(id, cancellationToken);

        return PurposeMapper.ToDto(purpose);
    }

    public async Task<PurposeDTO?> GetPurposeByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var purpose = await _purposeRepository.GetPurposeByIdAsync(id, cancellationToken);

        if (purpose is null)
        {
            throw new PurposeNotFoundException(id);
        }

        return PurposeMapper.ToDto(purpose);
    }

    public async Task<List<PurposeDTO>> GetPurposesAsync(CancellationToken cancellationToken = default)
    {
        var purpose = await _purposeRepository.GetPurposesAsync(cancellationToken);

        return purpose.Select(PurposeMapper.ToDto).ToList();
    }

    public async Task<PurposeDTO> UpdatePurposeAsync(Guid id, PurposeDTO purposeDTO)
    {
        var result = await _purposeRepository.GetPurposeByIdAsync(id);

        if (result == null)
        {
            throw new KeyNotFoundException($"Purpose with ID {id} not found.");
        }

        result.Name = purposeDTO.Name;
        result.Description = purposeDTO.Description;
        result.StartDate = purposeDTO.StartDate;
        result.EndDate = purposeDTO.EndDate;

        return PurposeMapper.ToDto(await _purposeRepository.UpdatePurposeAsync(result));
    }
}
