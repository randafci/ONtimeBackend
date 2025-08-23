using Microsoft.AspNetCore.Mvc;
using OnTime.CrossCutting.Data.Repository;
using OnTime.Module.lookup.DTO.Employee;
using OnTime.Data.Entities.Employee;
using AutoMapper;

namespace OnTime.Lookups.Domain.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeDocumentController : ControllerBase
    {
        private readonly ICrossCuttingRepository<EmployeeDocument> _repository;
        private readonly IMapper _mapper;

        public EmployeeDocumentController(ICrossCuttingRepository<EmployeeDocument> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documents = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<EmployeeDocumentDto>>(documents);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var document = await _repository.GetByIdAsync(id);
            if (document == null) return NotFound();
            var dto = _mapper.Map<EmployeeDocumentDto>(document);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDocumentDto dto)
        {
            var document = _mapper.Map<EmployeeDocument>(dto);
            var result = await _repository.AddAsync(document);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeDocumentDto dto)
        {
            var document = await _repository.GetByIdAsync(id);
            if (document == null) return NotFound();
            
            _mapper.Map(dto, document);
            await _repository.UpdateAsync(document);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var document = await _repository.GetByIdAsync(id);
            if (document == null) return NotFound();
            
            await _repository.DeleteAsync(document);
            return NoContent();
        }
    }
}
