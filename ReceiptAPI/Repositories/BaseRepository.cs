using ReceiptAPI.Context;
using ReceiptAPI.Repositories.Interfaces;
using System.Threading.Tasks;

namespace ReceiptAPI.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ReceiptContext _context;

        public BaseRepository(ReceiptContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
