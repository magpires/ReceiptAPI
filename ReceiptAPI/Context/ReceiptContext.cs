using Microsoft.EntityFrameworkCore;
using ReceiptAPI.Entities;

namespace ReceiptAPI.Context
{
    public class ReceiptContext : DbContext
    {
        public ReceiptContext(DbContextOptions<ReceiptContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
