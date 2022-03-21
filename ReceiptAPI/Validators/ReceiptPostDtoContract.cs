using Flunt.Validations;
using ReceiptAPI.Dtos.Request;

namespace ReceiptAPI.Validators
{
    public class ReceiptPostDtoContract : Contract<ReceiptPostDtoContract>
    {
        public ReceiptPostDtoContract(ReceiptPostDto receipt)
        {
            Requires()
                .IsGreaterThan(receipt.CustomerId, 0, "customerIdIsGreaterThan", "O id do cliente não pode ser menor ou igual a 0.")
                .IsGreaterThan(receipt.PaymentMethod, 0, "paymentMethodIsGreaterThan", "Método de pagamento inválido.")
                .IsLowerOrEqualsThan(receipt.PaymentMethod, 4, "paymentMethodIsLowerOrEqualsThan", "Método de pagamento inválido.")
                .IsNotNull(receipt.ProductReceipts, "productReceiptsIsNotNull", "Nenhum produto foi adicionado a nota fiscal.")
                .IsNotEmpty(receipt.ProductReceipts, "productReceiptsIsNotEmpty", "Nenhum produto foi adicionado a nota fiscal.");
        }
    }
}
