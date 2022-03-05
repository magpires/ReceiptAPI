using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Dtos.Response;
using System.Threading.Tasks;

namespace ReceiptAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseDto> GetUsersAsync();
        Task<ResponseDto> GetUserByIdAsync(int id);
        //Task<ResponseDto> PostUserAsync(UserPostDto user);
        //Task<ResponseDto> UpdateUserAsync(int id, UserUpdateDto user);
        //Task<ResponseDto> DeleteUserAsync(int id);
    }
}
 