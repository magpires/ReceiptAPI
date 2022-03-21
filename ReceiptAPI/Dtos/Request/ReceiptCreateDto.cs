using ReceiptAPI.Enumerators;
using ReceiptAPI.Validators;
using System.Collections.Generic;

namespace ReceiptAPI.Dtos.Request
{
    public class ReceiptCreateDto
    {
        public int CustomerId { get; set; }
        public List<ProductReceiptCreateDto> ProductReceipts { get; set; }
        public int PaymentMethod { get; set; }

        public ReceiptCreateDtoContract Validate()
        {
            return new ReceiptCreateDtoContract(this);
        }
    }
}
