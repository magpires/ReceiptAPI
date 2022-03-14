using ReceiptAPI.Validators;

namespace ReceiptAPI.Dtos.Request
{
    public class ProductUpdateDto
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public ProductUpdateDtoContract Validate()
        {
            return new ProductUpdateDtoContract(this);
        }
    }
}
