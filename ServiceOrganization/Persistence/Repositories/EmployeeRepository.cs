using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.ContextDB;

namespace Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly RepositoryDbContext _context;
    public EmployeeRepository(RepositoryDbContext context)
    {
        _context = context;
    }
    public async Task<Employee> AddEmployeeAsync(Employee employees)
    {
        await _context.Employees.AddAsync(employees);
        await _context.SaveChangesAsync();

        return employees;
    }

    public async Task DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var employees = await _context.Employees.FindAsync(id, cancellationToken);

        if (employees is not null)
        {
            _context.Employees.Remove(employees);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Employees.FindAsync(id, cancellationToken);
    }

    public async Task<List<Employee>> GetEmployeesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Employees.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Employee> UpdateEmployeeAsync(Employee employees)
    {
        _context.Employees.Update(employees);
        await _context.SaveChangesAsync();

        return employees;
    }
}
