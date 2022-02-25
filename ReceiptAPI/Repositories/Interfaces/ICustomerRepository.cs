using ReceiptAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceiptAPI.Repositories.Interfaces
{
    public interface ICustomerRepository : IBaseRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
    }
}
