using System.Collections.Generic;

namespace ReceiptAPI.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Receipt> Receipts { get; set; }
        public List<ProductReceipt> ProductReceipts { get; set; }
    }
}
