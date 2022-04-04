
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Services;
using ReceiptAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace ReceiptAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class EnumController : ControllerBase
    {

        public EnumController()
        {
        }

        [HttpGet("PaymentsMethods")]
        public IActionResult GetPaymentsMethods()
        {
            var response = EnumService.GetPaymentsMethods();

            return StatusCode(response.StatusCode, response);
        }
    }
}
