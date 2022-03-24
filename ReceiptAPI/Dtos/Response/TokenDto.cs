using System;

namespace ReceiptAPI.Dtos.Response
{
    public class TokenDto
    {
        public UserDetailsDto User { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
