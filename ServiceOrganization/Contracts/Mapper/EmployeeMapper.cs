using Contract;
using Domain.Entities;

namespace Contract.Mapper;

public class EmployeeMapper
{
    public static EmployeeDTO ToDto(Employee employee)
    {
        if (employee == null) throw new ArgumentNullException(nameof(employee));

        return new EmployeeDTO
        {
            Id = employee.Id,
            OrganizationId = employee.OrganizationId,
            FirstName = employee.FirstName,
            MiddleName = employee.MiddleName,
            LastName = employee.LastName,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber
        };
    }

    public static Employee ToEntity(EmployeeDTO employeeDto)
    {
        if (employeeDto == null) throw new ArgumentNullException(nameof(employeeDto));

        return new Employee
        {
            Id = employeeDto.Id,
            OrganizationId = employeeDto.OrganizationId,
            FirstName = employeeDto.FirstName,
            MiddleName = employeeDto.MiddleName,
            LastName = employeeDto.LastName,
            Email = employeeDto.Email,
            PhoneNumber = employeeDto.PhoneNumber
        };
    }
}
