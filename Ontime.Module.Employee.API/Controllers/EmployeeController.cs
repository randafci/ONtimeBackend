using Microsoft.AspNetCore.Mvc;
using OnTime.Employee.Services.DTO;
using OnTime.Employee.Services.Interfaces;
using OnTime.ResponseHandler.Models;
using System.Net;

namespace OnTime.Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ApiControllerBase
    {
        #region fields
        private readonly IEmployeeService _employeeService;
        #endregion

        #region ctor
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeService.GetAllEmployeesWithRelatedDataAsync();
            return ProcessResponse(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _employeeService.GetEmployeeByIdWithRelatedDataAsync(id);
            return ProcessResponse(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] EmployeeDto dto)
        {
            var result = await _employeeService.CreateEmployeeAsync(dto);
            return ProcessResponse(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeDto dto)
        {
            var result = await _employeeService.UpdateEmployeeAsync(id, dto);
            return ProcessResponse(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            return ProcessResponse(result);
        }
    }
}
