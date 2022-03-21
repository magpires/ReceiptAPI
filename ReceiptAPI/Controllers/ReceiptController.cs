
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace ReceiptAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _service;

        public ReceiptController(IReceiptService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _service.GetReceiptsAsync();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("/Customer/{customerId}")]
        public async Task<IActionResult> GetByCustomerIdAsync(int customerId)
        {
            var response = await _service.GetReceiptsByCustomerIdAsync(customerId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _service.GetReceiptByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(ReceiptCreateDto receipt)
        {
            var response = await _service.PostReceiptAsync(receipt);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, ReceiptUpdateDto receipt)
        {
            var response = await _service.UpdateReceiptAsync(id,receipt);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _service.DeleteReceiptAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}
