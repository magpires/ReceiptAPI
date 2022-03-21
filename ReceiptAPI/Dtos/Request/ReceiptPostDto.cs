using ReceiptAPI.Enumerators;
using ReceiptAPI.Validators;
using System.Collections.Generic;

namespace ReceiptAPI.Dtos.Request
{
    public class ReceiptPostDto
    {
        public int CustomerId { get; set; }
        public List<ProductReceiptPostDto> ProductReceipts { get; set; }
        public int PaymentMethod { get; set; }

        public ReceiptPostDtoContract Validate()
        {
            return new ReceiptPostDtoContract(this);
        }
    }
}
