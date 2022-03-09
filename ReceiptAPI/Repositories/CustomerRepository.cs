using Microsoft.EntityFrameworkCore;
using ReceiptAPI.Context;
using ReceiptAPI.Entities;
using ReceiptAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        private readonly ReceiptContext _context;
        public CustomerRepository(ReceiptContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Set<Customer>().ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Set<Customer>().FindAsync(id);
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await _context.Set<Customer>().Where(c => c.Email == email).FirstOrDefaultAsync();
        }
    }
}
