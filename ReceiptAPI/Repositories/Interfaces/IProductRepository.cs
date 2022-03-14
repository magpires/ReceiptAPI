using ReceiptAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceiptAPI.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
    }
}
