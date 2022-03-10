using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Dtos.Response;
using System.Threading.Tasks;

namespace ReceiptAPI.Services.Interfaces
{
    public interface ILoginService
    {
        Task<ResponseDto> AuthenticateAsync(UserLoginPostDto user);
    }
}
 