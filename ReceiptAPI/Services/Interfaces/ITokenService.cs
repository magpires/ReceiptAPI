using ReceiptAPI.Entities;

namespace ReceiptAPI.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
