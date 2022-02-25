using ReceiptAPI.Dtos.Response;
using System.Threading.Tasks;

namespace ReceiptAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<ResponseDto> GetCustomersAsync();
        //Task<ResponseDto> GetCustomerByIdAsync(int id);
        //Task<ResponseDto> PostCustomerAsync(CustomerPostDto customer);
        //Task<ResponseDto> UpdateCustomerAsync(int id, CustomerUpdateDto customer);
        //Task<ResponseDto> DeleteCustomerAsync(int id);
    }
}
