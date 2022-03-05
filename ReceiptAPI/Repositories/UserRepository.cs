
using Microsoft.EntityFrameworkCore;
using ReceiptAPI.Context;
using ReceiptAPI.Entities;
using ReceiptAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceiptAPI.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly ReceiptContext _context;
        public UserRepository(ReceiptContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Set<User>().ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Set<User>().FindAsync(id);
        }
    }
}
