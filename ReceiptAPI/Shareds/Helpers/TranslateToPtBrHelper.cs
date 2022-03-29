using ReceiptAPI.Enumerators;

namespace ReceiptAPI.Shared.Helpers
{
    public static class TranslateToPtBrHelper
    {
        public static string TranslatePaymentMethod(PaymentMethod paymentMethod)
        {
            if (paymentMethod == PaymentMethod.CASH)
            {
                return "Dinheiro";
            }

            if (paymentMethod == PaymentMethod.CREDITCARD)
            {
                return "Crédito";
            }
            return "Método de pagamento desconhecido";
        }
    }
}
