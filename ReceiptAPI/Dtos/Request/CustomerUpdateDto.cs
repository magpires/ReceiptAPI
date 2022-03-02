using ReceiptAPI.Validators;

namespace ReceiptAPI.Dtos.Request
{
    public class CustomerUpdateDto
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

        public CustomerUpdateDtoContract Validate()
        {
            return new CustomerUpdateDtoContract(this);
        }
    }
}
