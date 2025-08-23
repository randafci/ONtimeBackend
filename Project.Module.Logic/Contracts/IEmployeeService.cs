using OnTime.Module.lookup.DTO.Employee;
using OnTime.ResponseHandler.Models;

namespace OnTime.Module.Logic.Contracts
{
    public interface IEmployeeService
    {
        Task<APIOperationResponse<List<EmployeeDto>>> GetAllEmployeesWithRelatedDataAsync();
        Task<APIOperationResponse<EmployeeDto>> GetEmployeeByIdWithRelatedDataAsync(int id);
        Task<APIOperationResponse<EmployeeDto>> CreateEmployeeAsync(EmployeeDto employeeDto);
        Task<APIOperationResponse<EmployeeDto>> UpdateEmployeeAsync(int id, EmployeeDto employeeDto);
        Task<APIOperationResponse<bool>> DeleteEmployeeAsync(int id);
    }
}
