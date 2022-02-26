using ReceiptAPI.Dtos.Response;
using ReceiptAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace ReceiptAPI.Services
{
    public class CustomerService : ICustomerService
    {
        public Task<ResponseDto> GetCustomersAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
