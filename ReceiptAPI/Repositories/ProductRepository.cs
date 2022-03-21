using Microsoft.EntityFrameworkCore;
using ReceiptAPI.Context;
using ReceiptAPI.Entities;
using ReceiptAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly ReceiptContext _context;
        public ProductRepository(ReceiptContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Set<Product>().ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsByIdsAsync(int[] ids)
        {
            return await _context.Set<Product>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Set<Product>().FindAsync(id);
        }
    }
}
