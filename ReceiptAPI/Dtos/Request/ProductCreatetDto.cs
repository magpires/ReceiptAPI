using ReceiptAPI.Validators;

namespace ReceiptAPI.Dtos.Request
{
    public class ProductCreatetDto
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public ProductCreateDtoContract Validate()
        {
            return new ProductCreateDtoContract(this);
        }
    }
}
