using ReceiptAPI.Entities;
using ReceiptAPI.Enumerators;
using System;
using System.Collections.Generic;

namespace ReceiptAPI.Dtos.Response
{
    public class ReceiptDetailsDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public List<ProductReceiptDetailsDto> Products { get; set; }
        public string PaymentMethod { get; set; }
        public double Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public void CalculateTotalReceipt()
        {
            Products.ForEach(p =>
            {
                Total += p.Total;
            });
        }
    }
}
