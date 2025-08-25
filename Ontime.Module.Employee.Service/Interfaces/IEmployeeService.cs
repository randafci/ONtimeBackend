using OnTime.Employee.Services.DTO;
using OnTime.ResponseHandler.Models;

namespace OnTime.Employee.Services.Interfaces
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
