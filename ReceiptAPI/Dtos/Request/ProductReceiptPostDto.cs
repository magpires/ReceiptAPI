using ReceiptAPI.Enumerators;
using ReceiptAPI.Validators;
using System.Collections.Generic;

namespace ReceiptAPI.Dtos.Request
{
    public class ProductReceiptPostDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public ProductReceiptPostDtoContract Validate()
        {
            return new ProductReceiptPostDtoContract(this);
        }
    }
}
