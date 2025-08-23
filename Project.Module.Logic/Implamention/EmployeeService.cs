using AutoMapper;
using OnTime.CrossCutting.Data.Repository;
using OnTime.Data.Entities.Employee;
using OnTime.Module.Logic.Contracts;
using OnTime.Module.lookup.DTO.Employee;
using OnTime.ResponseHandler.Consts;
using OnTime.ResponseHandler.Models;

namespace OnTime.Module.Logic.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ICrossCuttingRepository<Employee> _employeeRepository;
        private readonly ICrossCuttingRepository<EmployeeContact> _contactRepository;
        private readonly ICrossCuttingRepository<EmployeeDocument> _documentRepository;
        private readonly IMapper _mapper;

        public EmployeeService(
            ICrossCuttingRepository<Employee> employeeRepository,
            ICrossCuttingRepository<EmployeeContact> contactRepository,
            ICrossCuttingRepository<EmployeeDocument> documentRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _contactRepository = contactRepository;
            _documentRepository = documentRepository;
            _mapper = mapper;
        }

        public async Task<APIOperationResponse<List<EmployeeDto>>> GetAllEmployeesWithRelatedDataAsync()
        {
            try
            {
              
                var employees = await _employeeRepository.FindAsync(
                    e => true, 
                    false, 
                    "Contact", "Document" 
                );

                var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
                return APIOperationResponse<List<EmployeeDto>>.Success(employeeDtos);
            }
            catch (Exception ex)
            {
                return APIOperationResponse<List<EmployeeDto>>.Fail(ResponseType.InternalServerError, CommonErrorCodes.OPERATION_FAILED, $"Error retrieving employees: {ex.Message}");
            }
        }

        public async Task<APIOperationResponse<EmployeeDto>> GetEmployeeByIdWithRelatedDataAsync(int id)
        {
            try
            {
             
                var employee = await _employeeRepository.FindOneAsync(
                    e => e.Id == id,
                    false, 
                    "Contact", "Document" 
                );

                if (employee == null)
                    return APIOperationResponse<EmployeeDto>.Fail(ResponseType.NotFound, CommonErrorCodes.NOT_FOUND, $"Employee with id {id} not found.");

                var employeeDto = _mapper.Map<EmployeeDto>(employee);
                return APIOperationResponse<EmployeeDto>.Success(employeeDto);
            }
            catch (Exception ex)
            {
                return APIOperationResponse<EmployeeDto>.Fail(ResponseType.InternalServerError, CommonErrorCodes.OPERATION_FAILED, $"Error retrieving employee: {ex.Message}");
            }
        }

        public async Task<APIOperationResponse<EmployeeDto>> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            try
            {
                // Check if employee code already exists
                var existingEmployee = await _employeeRepository.FindOneAsync(e => e.EmployeeCode == employeeDto.EmployeeCode);
                if (existingEmployee != null)
                    return APIOperationResponse<EmployeeDto>.Fail(ResponseType.BadRequest, CommonErrorCodes.OPERATION_FAILED, $"Employee with code {employeeDto.EmployeeCode} already exists.");

                var employee = _mapper.Map<Employee>(employeeDto);
                var result = await _employeeRepository.AddAsync(employee);

                // Create contact if provided
                if (employeeDto.Contact != null)
                {
                    var contact = _mapper.Map<EmployeeContact>(employeeDto.Contact);
                    contact.EmployeeId = result.Id;
                    await _contactRepository.AddAsync(contact);
                }

                // Create document if provided
                if (employeeDto.Document != null)
                {
                    var document = _mapper.Map<EmployeeDocument>(employeeDto.Document);
                    document.EmployeeId = result.Id;
                    await _documentRepository.AddAsync(document);
                }

                // Return the complete employee with related data
                return await GetEmployeeByIdWithRelatedDataAsync(result.Id);
            }
            catch (Exception ex)
            {
                return APIOperationResponse<EmployeeDto>.Fail(ResponseType.InternalServerError, CommonErrorCodes.OPERATION_FAILED, $"Error creating employee: {ex.Message}");
            }
        }

        public async Task<APIOperationResponse<EmployeeDto>> UpdateEmployeeAsync(int id, EmployeeDto employeeDto)
        {
            try
            {
                var existingEmployee = await _employeeRepository.GetByIdAsync(id);
                if (existingEmployee == null)
                    return APIOperationResponse<EmployeeDto>.Fail(ResponseType.NotFound, CommonErrorCodes.NOT_FOUND, $"Employee with id {id} not found.");

                // Check if employee code already exists for different employee
                var duplicateEmployee = await _employeeRepository.FindOneAsync(e => e.EmployeeCode == employeeDto.EmployeeCode && e.Id != id);
                if (duplicateEmployee != null)
                    return APIOperationResponse<EmployeeDto>.Fail(ResponseType.BadRequest, CommonErrorCodes.OPERATION_FAILED, $"Employee with code {employeeDto.EmployeeCode} already exists.");

                // Update employee
                _mapper.Map(employeeDto, existingEmployee);
                await _employeeRepository.UpdateAsync(existingEmployee);

                // Update or create contact
                if (employeeDto.Contact != null)
                {
                    var existingContact = await _contactRepository.FindOneAsync(c => c.EmployeeId == id);
                    if (existingContact != null)
                    {
                        _mapper.Map(employeeDto.Contact, existingContact);
                        await _contactRepository.UpdateAsync(existingContact);
                    }
                    else
                    {
                        var contact = _mapper.Map<EmployeeContact>(employeeDto.Contact);
                        contact.EmployeeId = id;
                        await _contactRepository.AddAsync(contact);
                    }
                }

                // Update or create document
                if (employeeDto.Document != null)
                {
                    var existingDocument = await _documentRepository.FindOneAsync(d => d.EmployeeId == id);
                    if (existingDocument != null)
                    {
                        _mapper.Map(employeeDto.Document, existingDocument);
                        await _documentRepository.UpdateAsync(existingDocument);
                    }
                    else
                    {
                        var document = _mapper.Map<EmployeeDocument>(employeeDto.Document);
                        document.EmployeeId = id;
                        await _documentRepository.AddAsync(document);
                    }
                }

                // Return the complete employee with related data
                return await GetEmployeeByIdWithRelatedDataAsync(id);
            }
            catch (Exception ex)
            {
                return APIOperationResponse<EmployeeDto>.Fail(ResponseType.InternalServerError, CommonErrorCodes.OPERATION_FAILED, $"Error updating employee: {ex.Message}");
            }
        }

        public async Task<APIOperationResponse<bool>> DeleteEmployeeAsync(int id)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(id);
                if (employee == null)
                    return APIOperationResponse<bool>.Fail(ResponseType.NotFound, CommonErrorCodes.NOT_FOUND, $"Employee with id {id} not found.");

           
                await _employeeRepository.DeleteAsync(employee);
                return APIOperationResponse<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return APIOperationResponse<bool>.Fail(ResponseType.InternalServerError, CommonErrorCodes.OPERATION_FAILED, $"Error deleting employee: {ex.Message}");
            }
        }
    }
}
