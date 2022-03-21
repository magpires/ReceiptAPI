using Flunt.Validations;
using ReceiptAPI.Dtos.Request;

namespace ReceiptAPI.Validators
{
    public class ReceiptUpdateDtoContract : Contract<ReceiptUpdateDtoContract>
    {
        public ReceiptUpdateDtoContract(ReceiptUpdateDto receipt)
        {
            Requires()
                .IsGreaterThan(receipt.PaymentMethod, 0, "paymentMethodIsGreaterThan", "Método de pagamento inválido.")
                .IsLowerOrEqualsThan(receipt.PaymentMethod, 4, "paymentMethodIsLowerOrEqualsThan", "Método de pagamento inválido.")
                .IsNotNull(receipt.ProductReceipts, "productReceiptsIsNotNull", "Nenhum produto foi adicionado a nota fiscal.")
                .IsNotEmpty(receipt.ProductReceipts, "productReceiptsIsNotEmpty", "Nenhum produto foi adicionado a nota fiscal.");
        }
    }
}
