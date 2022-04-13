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
            var phoneNumberNotEmpty = phoneNumber.Length > 0;

            if (phoneNumberNotEmpty)
                return long.Parse(phoneNumber).ToString(@"(00) 00000-0000");
            return "";
        }

        public static string FormatPostalCode(string postalCode)
        {
            var postalCodeNotEmpty = postalCode.Length > 0;

            if (postalCodeNotEmpty)
                return Convert.ToUInt64(postalCode).ToString(@"00000\-000");
            return "";
        }
    }
}
