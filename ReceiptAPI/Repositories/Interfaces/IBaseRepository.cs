using System.Threading.Tasks;

namespace ReceiptAPI.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        public void Add<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
        public Task<bool> SaveChangesAsync();
    }
}
