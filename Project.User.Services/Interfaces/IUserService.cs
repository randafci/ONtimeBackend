using OnTime.ResponseHandler.Models;
using OnTime.User.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.User.Services.Interfaces
{
  
        public interface IUserService
        {
            Task<APIOperationResponse<UserDto>> GetByIdAsync(string id);
            Task<APIOperationResponse<List<UserDto>>> GetAllAsync();
            Task<APIOperationResponse<UserDto>> CreateAsync(CreateUserDto dto);
            Task<APIOperationResponse<UserDto>> UpdateAsync(UpdateUserDto dto);
            Task<APIOperationResponse<bool>> DeleteAsync(string id);
        }

    

}
