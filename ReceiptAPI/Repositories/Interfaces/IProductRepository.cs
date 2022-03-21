using ReceiptAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceiptAPI.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<Product>> GetProductsByIdsAsync(int[] ids);
        Task<Product> GetProductByIdAsync(int id);
    }
}
