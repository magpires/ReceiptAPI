using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReceiptClient.Dtos.Request;
using ReceiptClient.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReceiptClient.Controllers
{
    public class AuthController
    {
        public static async void Login(UserLoginPostDto user)
        {
            string URI = "https://receiptapi22.herokuapp.com/api/Auth/Login";

            using (var client = new HttpClient())
            {
                var serializedLogin = JsonConvert.SerializeObject(user);
                var content = new StringContent(serializedLogin, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                var jsonString = await result.Content.ReadAsStringAsync();
                var tokenData = JObject.Parse(jsonString);
                string token = (string)tokenData.SelectToken("data.token");
            }
        }
    }
}
