using System.Collections.Generic;

namespace ReceiptAPI.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<Receipt> Receipts { get; set; }
    }
}
