using ReceiptAPI.Enumerators;

namespace ReceiptAPI.Dtos.Response
{
    public class PaymentMethodDto
    {
        public PaymentMethod PaymentMethod { get; set; }
        public string Description { get; set; }
    }
}
