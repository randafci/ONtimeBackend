using Microsoft.AspNetCore.Identity;
using OnTime.Comman.Idenitity;
using OnTime.CrossCutting.Data.Repository;
using OnTime.Data.Entities.Employee;
using OnTime.ResponseHandler.Consts;
using OnTime.ResponseHandler.Models;
using OnTime.User.Services.DTO;
using OnTime.User.Services.Interfaces;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly CrossCuttingRepository<Employee> _employeeRepository;

    public UserService(UserManager<ApplicationUser> userManager, CrossCuttingRepository<Employee> employeeRepository)
    {
        _userManager = userManager;
        _employeeRepository = employeeRepository;
    }

    public async Task<APIOperationResponse<UserDto>> GetByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return APIOperationResponse<UserDto>.Fail(ResponseType.NotFound, "User not found");

        return APIOperationResponse<UserDto>.Success(MapToDto(user));
    }

    public async Task<APIOperationResponse<List<UserDto>>> GetAllAsync()
    {
        var users = _userManager.Users.ToList();
        var mapped = users.Select(MapToDto).ToList();
        return APIOperationResponse<List<UserDto>>.Success(mapped);
    }

    public async Task<APIOperationResponse<UserDto>> CreateAsync(CreateUserDto dto)
    {
        var emp = await _employeeRepository.FindOneAsync(x=>x.Id==dto.EmployeeId);
        if (emp==null)
            return APIOperationResponse<UserDto>.Fail(OnTime.ResponseHandler.Consts.ResponseType.NotFound,
              "employee not found");
        var user = new ApplicationUser
        {
            UserName = emp.EmployeeCode,
            Email = emp.EmployeeCode,
            IsLdapUser = dto.IsLdapUser,
            ExtraEmployeesView = dto.ExtraEmployeesView,
            EmployeeId = dto.EmployeeId
        };

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
            return APIOperationResponse<UserDto>.Fail(OnTime.ResponseHandler.Consts.ResponseType.BadRequest,
                string.Join(",", result.Errors.Select(e => e.Description)));

        return APIOperationResponse<UserDto>.Success(MapToDto(user));
    }

    public async Task<APIOperationResponse<UserDto>> UpdateAsync(UpdateUserDto dto)
    {
        var user = await _userManager.FindByIdAsync(dto.Id);
        if (user == null)
            return APIOperationResponse<UserDto>.Fail(ResponseType.NotFound, "User not found");

        user.UserName = dto.UserName;
        user.Email = dto.Email;
        user.IsLdapUser = dto.IsLdapUser;
        user.ExtraEmployeesView = dto.ExtraEmployeesView;
        user.EmployeeId = dto.EmployeeId;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
            return APIOperationResponse<UserDto>.Fail(ResponseType.InternalServerError,
                string.Join(",", result.Errors.Select(e => e.Description)));

        return APIOperationResponse<UserDto>.Success(MapToDto(user));
    }

    public async Task<APIOperationResponse<bool>> DeleteAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return APIOperationResponse<bool>.Fail(ResponseType.NotFound, "User not found");

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
            return APIOperationResponse<bool>.Fail(ResponseType.InternalServerError,
                string.Join(",", result.Errors.Select(e => e.Description)));

        return APIOperationResponse<bool>.Success(true, "User deleted successfully");
    }

    private UserDto MapToDto(ApplicationUser user) =>
        new()
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            IsLdapUser = user.IsLdapUser,
            ExtraEmployeesView = user.ExtraEmployeesView,
            EmployeeId = user.EmployeeId
        };
}
