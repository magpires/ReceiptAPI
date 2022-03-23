using Newtonsoft.Json;
using ReceiptClient.Controllers.Interfaces;
using ReceiptClient.Dtos.Request;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptClient.Controllers
{
    public class AuthController : IAuthController
    {

        public async Task<HttpResponseMessage> Login(UserLoginPostDto user)
        {
            string URI = "https://receiptapi22.herokuapp.com/api/Auth/Login";

            using (var client = new HttpClient())
            {
                var serializedLogin = JsonConvert.SerializeObject(user);
                var content = new StringContent(serializedLogin, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);
                return result;
            }
        }

        public async Task<HttpResponseMessage> Register(UserCreateDto user)
        {
            string URI = "https://receiptapi22.herokuapp.com/api/Auth/Register";

            using (var client = new HttpClient())
            {
                var serializedRegister = JsonConvert.SerializeObject(user);
                var content = new StringContent(serializedRegister, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);
                return result;
            }
        }
    }
}
