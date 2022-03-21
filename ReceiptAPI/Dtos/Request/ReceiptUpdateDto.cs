using ReceiptAPI.Enumerators;
using ReceiptAPI.Validators;
using System.Collections.Generic;

namespace ReceiptAPI.Dtos.Request
{
    public class ReceiptUpdateDto
    {
        public List<ProductReceiptUpdateDto> ProductReceipts { get; set; }
        public int PaymentMethod { get; set; }

        public ReceiptUpdateDtoContract Validate()
        {
            return new ReceiptUpdateDtoContract(this);
        }
    }
}
