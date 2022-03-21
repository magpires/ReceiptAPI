using ReceiptAPI.Enumerators;
using ReceiptAPI.Validators;
using System.Collections.Generic;

namespace ReceiptAPI.Dtos.Request
{
    public class ProductReceiptUpdateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public ProductReceiptUpdateDtoContract Validate()
        {
            return new ProductReceiptUpdateDtoContract(this);
        }
    }
}
