using Microsoft.AspNetCore.Mvc;
using OnTime.CrossCutting.Data.Repository;
using OnTime.Module.lookup.DTO.Employee;
using OnTime.Data.Entities.Employee;
using AutoMapper;

namespace OnTime.Lookups.Domain.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeContactController : ControllerBase
    {
        private readonly ICrossCuttingRepository<EmployeeContact> _repository;
        private readonly IMapper _mapper;

        public EmployeeContactController(ICrossCuttingRepository<EmployeeContact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<EmployeeContactDto>>(contacts);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact == null) return NotFound();
            var dto = _mapper.Map<EmployeeContactDto>(contact);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeContactDto dto)
        {
            var contact = _mapper.Map<EmployeeContact>(dto);
            var result = await _repository.AddAsync(contact);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeContactDto dto)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact == null) return NotFound();
            
            _mapper.Map(dto, contact);
            await _repository.UpdateAsync(contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact == null) return NotFound();
            
            await _repository.DeleteAsync(contact);
            return NoContent();
        }
    }
}
