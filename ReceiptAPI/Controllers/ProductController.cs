
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _service.GetProductsAsync();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _service.GetProductByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(ProductCreatetDto product)
        {
            var response = await _service.PostProductAsync(product);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, ProductUpdateDto product)
        {
            var response = await _service.UpdateProductAsync(id, product);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _service.DeleteProductAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}
