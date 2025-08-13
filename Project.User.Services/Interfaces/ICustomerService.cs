using OnTime.ResponseHandler.Models;
using OnTime.Services.DataTransferObject.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<APIOperationResponse<CustomerSearchModel>> UpdateCustomerAsync(CustomerCreateModel model);
        Task<APIOperationResponse<CustomerSearchModel>> CreateCustomerAsync(CustomerCreateModel model);

        Task<APIOperationResponse<List<CustomerGetAllModel>>> GetAllCustomerAsync(string name, string phone, string email);
        Task<APIOperationResponse<bool>> DeleteCustomerAsync(int id);
    }
}
