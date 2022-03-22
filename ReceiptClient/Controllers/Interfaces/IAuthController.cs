using ReceiptClient.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptClient.Controllers.Interfaces
{
    public interface IAuthController
    {
        Task<HttpResponseMessage> Login(UserLoginPostDto user);
    }
}
