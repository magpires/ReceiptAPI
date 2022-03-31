using ReceiptAPI.Dtos.Response;
using ReceiptAPI.Enumerators;
using System.Collections.Generic;

namespace ReceiptAPI.Shared.Helpers
{
    public static class ReceiptHelper
    {
        public static double CalculateTotalReceiptPrice(List<ProductReceiptDetailsDto> products)
        {
            double total = 0;

            products.ForEach(p =>
            {
                total += p.Total;
            });

            return total;
        }
    }
}
