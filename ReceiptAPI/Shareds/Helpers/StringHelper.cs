using ReceiptAPI.Dtos.Response;
using ReceiptAPI.Enumerators;
using System;
using System.Collections.Generic;

namespace ReceiptAPI.Shared.Helpers
{
    public static class StringHelper
    {
        public static string FormatPhonNumbere(string phoneNumber)
        {
            return long.Parse(phoneNumber).ToString(@"(00) 00000-0000"); ;
        }

        public static string FormatPostalCode(string postalCode)
        {
            return Convert.ToUInt64(postalCode).ToString(@"00000\-000");
        }
    }
}
