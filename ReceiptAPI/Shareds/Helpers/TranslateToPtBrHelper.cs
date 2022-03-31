using ReceiptAPI.Enumerators;

namespace ReceiptAPI.Shared.Helpers
{
    public static class TranslateToPtBrHelper
    {
        public static string TranslatePaymentMethod(PaymentMethod paymentMethod)
        {

            switch (paymentMethod)
            {
                case PaymentMethod.CASH:
                    return "Dinheiro";
                case PaymentMethod.CREDITCARD:
                    return "Crédito";
            }
            return "Não identificado";
        }
    }
}
