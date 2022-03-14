using ReceiptAPI.Validators;

namespace ReceiptAPI.Dtos.Request
{
    public class ProductPostDto
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public ProductPostDtoContract Validate()
        {
            return new ProductPostDtoContract(this);
        }
    }
}
