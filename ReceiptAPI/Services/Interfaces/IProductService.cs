using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Dtos.Response;
using System.Threading.Tasks;

namespace ReceiptAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResponseDto> GetProductsAsync();
        Task<ResponseDto> GetProductByIdAsync(int id);
        Task<ResponseDto> PostProductAsync(ProductPostDto product);
        Task<ResponseDto> UpdateProductAsync(int id, ProductUpdateDto product);
        //Task<ResponseDto> DeleteProductAsync(int id);
    }
}
 