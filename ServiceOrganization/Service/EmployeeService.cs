using Contract;
using Contract.Mapper;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Services.Abstractions;
namespace Service;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeesRepository;

    public EmployeeService(IEmployeeRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employeeDTO)
    {
        return EmployeeMapper.ToDto(await _employeesRepository.AddEmployeeAsync(EmployeeMapper.ToEntity(employeeDTO)));
    }

    public async Task<EmployeeDTO?> DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var employee = await _employeesRepository.GetEmployeeByIdAsync(id, cancellationToken);

        if (employee == null)
        {
            throw new EmployeesNotFoundException(id);
        }
        await _employeesRepository.DeleteEmployeeAsync(id, cancellationToken);

        return EmployeeMapper.ToDto(employee);
    }

    public async Task<EmployeeDTO?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var employee = await _employeesRepository.GetEmployeeByIdAsync(id, cancellationToken);

        if (employee == null)
        {
            throw new EmployeesNotFoundException(id);
        }

        return EmployeeMapper.ToDto(employee);
    }

    public async Task<List<EmployeeDTO>> GetEmployeesAsync(CancellationToken cancellationToken = default)
    {
        var employees = await _employeesRepository.GetEmployeesAsync(cancellationToken);

        return employees.Select(EmployeeMapper.ToDto).ToList();
    }

    public async Task<EmployeeDTO> UpdateEmployeeAsync(Guid id, EmployeeDTO employeeDTO)
    {
        var result = await _employeesRepository.GetEmployeeByIdAsync(id);

        if (result == null)
        {
            throw new KeyNotFoundException($"Employee with ID {id} not found.");
        }

        result.LastName = employeeDTO.LastName;
        result.FirstName = employeeDTO.FirstName;
        result.MiddleName = employeeDTO.MiddleName;
        result.Email = employeeDTO.Email;
        result.PhoneNumber = employeeDTO.PhoneNumber;

        return EmployeeMapper.ToDto(await _employeesRepository.UpdateEmployeeAsync(result));
    }

}
