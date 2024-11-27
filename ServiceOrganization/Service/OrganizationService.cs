using System;
using Contract;
using Contract.Mapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstractions;

namespace Service;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _organizationRepository;

    public OrganizationService(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public async Task<OrganizationDTO> AddOrganizationsAsync(OrganizationDTO organizationsDTO)
    {
        return OrganizationMapper.ToDto(await _organizationRepository.AddOrganizationsAsync(OrganizationMapper.ToEntity(organizationsDTO)));
    }

    public async Task<OrganizationDTO?> DeleteOrganizationsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var organization = await _organizationRepository.GetOrganizationByIdAsync(id, cancellationToken);

        if (organization == null)
        {
            throw new OrganizationsNotFoundException(id);
        }
        await _organizationRepository.DeleteOrganizationsAsync(id, cancellationToken);

        return OrganizationMapper.ToDto(organization);
    }

    public async Task<OrganizationDTO?> GetOrganizationByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var organization = await _organizationRepository.GetOrganizationByIdAsync(id, cancellationToken);

        if (organization == null)
        {
            throw new OrganizationsNotFoundException(id);
        }

        return OrganizationMapper.ToDto(organization);
    }

    public async Task<List<OrganizationDTO>> GetOrganizationsAsync(CancellationToken cancellationToken = default)
    {
        var organization = await _organizationRepository.GetOrganizationsAsync(cancellationToken);

        return organization.Select(OrganizationMapper.ToDto).ToList();
    }

    public async Task<OrganizationDTO> UpdateOrganizationsAsync(Guid id, OrganizationDTO organizationsDTO)
    {
        var result = await _organizationRepository.GetOrganizationByIdAsync(id);

        if (result == null)
        {
            throw new KeyNotFoundException($"Organization with ID {id} not found.");
        }

        result.Name = organizationsDTO.Name;
        result.Address = organizationsDTO.Address;
        
        return OrganizationMapper.ToDto(await _organizationRepository.UpdateOrganizationsAsync(result));
    }
}
