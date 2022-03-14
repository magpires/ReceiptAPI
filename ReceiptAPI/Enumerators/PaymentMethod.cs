using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI.Enumerators
{
    public enum PaymentMethod
    {
        [Description("Dinheiro")]
        CASH = 1,
        [Description("Cartão de Crédito")]
        CREDITCARD = 2,
    }
}
