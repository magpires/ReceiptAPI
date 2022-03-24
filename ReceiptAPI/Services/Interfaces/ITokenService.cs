using ReceiptAPI.Dtos.Response;
using ReceiptAPI.Entities;

namespace ReceiptAPI.Services.Interfaces
{
    public interface ITokenService
    {
        TokenDto GenerateToken(User user);
    }
}
