using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptClient.Dtos.Response
{
    public class TokenDto
    {
        public UserDetailsDto? User { get; set; }
        public string? Token { get; set; }
    }
}
