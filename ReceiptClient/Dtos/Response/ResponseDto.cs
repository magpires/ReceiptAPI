using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptClient.Dtos.Response
{
    public class ResponseDto
    {
        public int statusCode { get; private set; }
        public object? data { get; private set; }
    }
}
