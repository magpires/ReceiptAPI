
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public CustomerController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return StatusCode(200, "Tá rodando");
        }
    }
}
