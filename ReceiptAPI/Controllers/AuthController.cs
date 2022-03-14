using Microsoft.AspNetCore.Mvc;
using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace ReceiptAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> AuthenticateAsync(UserLoginPostDto user)
        {
            var response = await _service.AuthenticateAsync(user);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(UserPostDto user)
        {
            var response = await _service.RegisterAsync(user);

            return StatusCode(response.StatusCode, response);
        }
    }
}
