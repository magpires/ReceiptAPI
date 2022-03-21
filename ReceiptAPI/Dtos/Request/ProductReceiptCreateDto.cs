using ReceiptAPI.Enumerators;
using ReceiptAPI.Validators;
using System.Collections.Generic;

namespace ReceiptAPI.Dtos.Request
{
    public class ProductReceiptCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public ProductReceiptCreateDtoContract Validate()
        {
            return new ProductReceiptCreateDtoContract(this);
        }
    }
}
