using Microsoft.AspNetCore.Mvc;
using OnTime.Module.lookup.DTO.Employee;
using OnTime.Module.Logic.Contracts;
using OnTime.ResponseHandler.Models;

namespace OnTime.Lookups.Domain.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeService.GetAllEmployeesWithRelatedDataAsync();
            if (result.Succeeded)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _employeeService.GetEmployeeByIdWithRelatedDataAsync(id);
            if (result.Succeeded)
                return Ok(result.Data);
            return NotFound(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDto dto)
        {
            var result = await _employeeService.CreateEmployeeAsync(dto);
            if (result.Succeeded)
                return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result.Data);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeDto dto)
        {
            var result = await _employeeService.UpdateEmployeeAsync(id, dto);
            if (result.Succeeded)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            if (result.Succeeded)
                return NoContent();
            return BadRequest(result.Message);
        }
    }
}