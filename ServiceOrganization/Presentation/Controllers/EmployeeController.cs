using Contract.Mapper;
using Contract;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System.Threading;
using Domain.Exceptions;
using Domain.Entities;

namespace Presentation.Controllers;

[ApiController]
[Route("api/Employees")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService) => _employeeService = employeeService;

    [HttpPost]
    public async Task<ActionResult<EmployeeDTO>> AddEmployeeAsync([FromBody] EmployeeDTO employeeDTO)
    {

        if (employeeDTO == null)
        {
            return BadRequest("Employee data is required.");
        }

        await _employeeService.AddEmployeeAsync(employeeDTO);

        return Created("", employeeDTO);
    }

    [HttpGet("{EmployeeId:guid}")]
    public async Task<ActionResult<EmployeeDTO>> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id, cancellationToken);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpDelete("{EmployeeId:guid}")]
    public async Task<IActionResult> DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var deletedEmployee = await _employeeService.DeleteEmployeeAsync(id, cancellationToken);
            return Ok(deletedEmployee); 
        }
        catch (EmployeesNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<EmployeeDTO>>> GetEmployeesAsync(CancellationToken cancellationToken = default)
    {
        var employees = await _employeeService.GetEmployeesAsync(cancellationToken);

        return Ok(employees);
    }

    [HttpPut("{EmployeeId:guid}")]
    public async Task<ActionResult<EmployeeDTO>> UpdateEmployeeAsync(Guid id, [FromBody] EmployeeDTO employeeDTO)
    {
        if (employeeDTO == null)
        {
            return BadRequest("Employee data is required.");
        }

        try
        {
            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, employeeDTO);

            return Ok(updatedEmployee); 
        }
        catch (EmployeesNotFoundException)
        {
            return NotFound(); 
        }
    }
}
