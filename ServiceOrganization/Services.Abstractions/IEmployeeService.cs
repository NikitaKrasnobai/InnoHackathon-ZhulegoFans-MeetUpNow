using Contract;
namespace Services.Abstractions;

public interface IEmployeeService
{
    public Task<EmployeeDTO?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<EmployeeDTO>> GetEmployeesAsync(CancellationToken cancellationToken = default);

    public Task<EmployeeDTO?> DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employeeDTO);

    public Task<EmployeeDTO> UpdateEmployeeAsync(Guid id, EmployeeDTO employeeDTO);
}
