using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Dtos.Response;
using System.Threading.Tasks;

namespace ReceiptAPI.Services.Interfaces
{
    public interface IReceiptService
    {
        Task<ResponseDto> GetReceiptsAsync();
        Task<ResponseDto> GetReceiptsByCustomerIdAsync(int customerId);
        Task<ResponseDto> GetReceiptByIdAsync(int id);
        Task<ResponseDto> PostReceiptAsync(ReceiptPostDto receipt);
        Task<ResponseDto> UpdateReceiptAsync(int id, ReceiptUpdateDto receipt);
        Task<ResponseDto> DeleteReceiptAsync(int id);
    }
}
 