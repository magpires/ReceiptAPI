using Microsoft.EntityFrameworkCore;
using ReceiptAPI.Context;
using ReceiptAPI.Entities;
using ReceiptAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI.Repositories
{
    public class ReceiptRepository : BaseRepository, IReceiptRepository
    {
        private readonly ReceiptContext _context;
        public ReceiptRepository(ReceiptContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsAsync()
        {
            return await _context.Set<Receipt>()
                .Include(x => x.Customer)
                .Include(x => x.Products)
                .ToListAsync();
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsByCustomerIdAsync(int customerId)
        {
            return await _context.Set<Receipt>()
                .Include(x => x.Customer)
                .Include(x => x.Products)
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Receipt> GetReceiptByIdAsync(int id)
        {
            return await _context.Set<Receipt>()
                .Include(x => x.Customer)
                .Include(x => x.Products)
                .Where(x =>x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
