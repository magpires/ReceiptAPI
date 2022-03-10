using Microsoft.AspNetCore.Mvc;
using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace ReceiptAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService service)
        {
            _loginService = service;
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync(UserLoginPostDto user)
        {
            var response = await _loginService.AuthenticateAsync(user);

            return StatusCode(response.StatusCode, response);
        }
    }
}
