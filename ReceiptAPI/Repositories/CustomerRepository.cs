using Microsoft.EntityFrameworkCore;
using ReceiptAPI.Context;
using ReceiptAPI.Entities;
using ReceiptAPI.Repositories.Interfaces;
using System.Collections.Generic;
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
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }
    }
}
