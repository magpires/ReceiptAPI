
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _service.GetCustomersAsync();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _service.GetCustomerByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CustomerPostDto customer)
        {
            var response = await _service.PostCustomerAsync(customer);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, CustomerUpdateDto customer)
        {
            var response = await _service.UpdateCustomerAsync(id, customer);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _service.DeleteCustomerAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}
