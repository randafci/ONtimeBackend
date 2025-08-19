using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnTime.ResponseHandler.Models;
using OnTime.Services.DataTransferObject.AuthenticationDto;
using OnTime.Services.DataTransferObject.Customer;
using OnTime.Services.Helpers;
using OnTime.Services.Interfaces;
namespace OnTime.Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ApiControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customer
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers(string name, string? phone, string ?email)
        {
            var response = await _customerService.GetAllCustomerAsync(name ,phone,email);
            return ProcessResponse(response);
        }

        // POST: api/customer
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _customerService.CreateCustomerAsync(model);
            return ProcessResponse(response);
        }

        // PUT: api/customer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _customerService.UpdateCustomerAsync(model);


            return ProcessResponse(response);
        }

        // DELETE: api/customer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _customerService.DeleteCustomerAsync(id);


            return ProcessResponse(response);
        }
    }

}
