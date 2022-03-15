
using ReceiptAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceiptAPI.Repositories.Interfaces
{
    public interface IReceiptRepository : IBaseRepository
    {
        Task<IEnumerable<Receipt>> GetReceiptsAsync();
        Task<IEnumerable<Receipt>> GetReceiptsByCustomerIdAsync(int customerId);
        Task<Receipt> GetReceiptByIdAsync(int id);
    }
}
