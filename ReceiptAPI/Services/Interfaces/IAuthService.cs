using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Dtos.Response;
using System.Threading.Tasks;

namespace ReceiptAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDto> AuthenticateAsync(UserLoginPostDto user);
        Task<ResponseDto> RegisterAsync(UserCreateDto user);
    }
}
 