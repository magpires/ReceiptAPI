using ReceiptAPI.Enumerators;
using System.Collections.Generic;

namespace ReceiptAPI.Entities
{
    public class Receipt : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductReceipt> ProductReceipts { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
