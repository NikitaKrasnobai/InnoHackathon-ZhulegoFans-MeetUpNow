using Domain.Entities;

namespace Domain.Repositories;

public interface IEmployeeRepository
{
    public Task<Employee?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<Employee>> GetEmployeesAsync(CancellationToken cancellationToken = default);

    public Task DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<Employee> AddEmployeeAsync(Employee employees);

    public Task<Employee> UpdateEmployeeAsync(Employee employees);
}
