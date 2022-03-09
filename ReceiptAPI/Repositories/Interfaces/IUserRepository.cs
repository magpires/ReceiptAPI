using ReceiptAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceiptAPI.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
    }
}
