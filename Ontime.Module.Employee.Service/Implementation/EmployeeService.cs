using AutoMapper;
using OnTime.CrossCutting.Data.Repository;
using OnTime.Data.Entities.Employee;
using EmployeeEntity = OnTime.Data.Entities.Employee.Employee;
using EmployeeContactEntity = OnTime.Data.Entities.Employee.EmployeeContact;
using EmployeeDocumentEntity = OnTime.Data.Entities.Employee.EmployeeDocument;
using OnTime.Employee.Services.Interfaces;
using OnTime.Employee.Services.DTO;
using OnTime.ResponseHandler.Consts;
using OnTime.ResponseHandler.Models;

namespace OnTime.Employee.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ICrossCuttingRepository<EmployeeEntity> _employeeRepository;
        private readonly ICrossCuttingRepository<EmployeeContactEntity> _contactRepository;
        private readonly ICrossCuttingRepository<EmployeeDocumentEntity> _documentRepository;
        private readonly IMapper _mapper;

        public EmployeeService(
            ICrossCuttingRepository<EmployeeEntity> employeeRepository,
            ICrossCuttingRepository<EmployeeContactEntity> contactRepository,
            ICrossCuttingRepository<EmployeeDocumentEntity> documentRepository,
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

                var employee = _mapper.Map<EmployeeEntity>(employeeDto);
                var result = await _employeeRepository.AddAsync(employee);

                // Create contact if provided
                if (employeeDto.Contact != null)
                {
                    employeeDto.Contact.EmployeeId = result.Id;
                    var contact = _mapper.Map<EmployeeContactEntity>(employeeDto.Contact);
                    await _contactRepository.AddAsync(contact);
                }

                // Create document if provided
                if (employeeDto.Document != null)
                {
                    employeeDto.Document.EmployeeId = result.Id;
                    var document = _mapper.Map<EmployeeDocumentEntity>(employeeDto.Document);
                    await _documentRepository.AddAsync(document);
                }

                // Get the complete employee with related data
                var createdEmployee = await _employeeRepository.FindOneAsync(
                    e => e.Id == result.Id,
                    false,
                    "Contact", "Document"
                );

                var createdEmployeeDto = _mapper.Map<EmployeeDto>(createdEmployee);
                return APIOperationResponse<EmployeeDto>.Success(createdEmployeeDto);
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
                var existingEmployee = await _employeeRepository.FindOneAsync(e => e.Id == id);
                if (existingEmployee == null)
                    return APIOperationResponse<EmployeeDto>.Fail(ResponseType.NotFound, CommonErrorCodes.NOT_FOUND, $"Employee with id {id} not found.");

                // Check if employee code already exists for different employee
                var employeeWithSameCode = await _employeeRepository.FindOneAsync(e => e.EmployeeCode == employeeDto.EmployeeCode && e.Id != id);
                if (employeeWithSameCode != null)
                    return APIOperationResponse<EmployeeDto>.Fail(ResponseType.BadRequest, CommonErrorCodes.OPERATION_FAILED, $"Employee with code {employeeDto.EmployeeCode} already exists.");

                // Update employee
                _mapper.Map(employeeDto, existingEmployee);
                await _employeeRepository.UpdateAsync(existingEmployee);

                // Update contact if provided
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
                        employeeDto.Contact.EmployeeId = id;
                        var contact = _mapper.Map<EmployeeContactEntity>(employeeDto.Contact);
                        await _contactRepository.AddAsync(contact);
                    }
                }

                // Update document if provided
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
                        employeeDto.Document.EmployeeId = id;
                        var document = _mapper.Map<EmployeeDocumentEntity>(employeeDto.Document);
                        await _documentRepository.AddAsync(document);
                    }
                }

                // Get the updated employee with related data
                var updatedEmployee = await _employeeRepository.FindOneAsync(
                    e => e.Id == id,
                    false,
                    "Contact", "Document"
                );

                var updatedEmployeeDto = _mapper.Map<EmployeeDto>(updatedEmployee);
                return APIOperationResponse<EmployeeDto>.Success(updatedEmployeeDto);
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
                var employee = await _employeeRepository.FindOneAsync(e => e.Id == id);
                if (employee == null)
                    return APIOperationResponse<bool>.Fail(ResponseType.NotFound, CommonErrorCodes.NOT_FOUND, $"Employee with id {id} not found.");

                // Delete related contact and document
                var contact = await _contactRepository.FindOneAsync(c => c.EmployeeId == id);
                if (contact != null)
                    await _contactRepository.DeleteAsync(contact);

                var document = await _documentRepository.FindOneAsync(d => d.EmployeeId == id);
                if (document != null)
                    await _documentRepository.DeleteAsync(document);

                // Delete employee
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
