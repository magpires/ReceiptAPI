using Flunt.Validations;
using ReceiptAPI.Dtos.Request;

namespace ReceiptAPI.Validators
{
    public class ProductCreateDtoContract : Contract<ProductCreateDtoContract>
    {
        public ProductCreateDtoContract(ProductCreatetDto product)
        {
            Requires()
                .IsNotNullOrEmpty(product.Name, "nameNotNullOrEmpty", "O nome do produto não pode ser nulo.")
                .IsLowerOrEqualsThan(product.Name, 255, "nameIsLowerOrEqualsThan", "O nome do produto não deve ter mais que 255 digitos.")
                .IsGreaterThan(product.Price, 0, "priceIsGreaterThan", "O preço do produto não pode ser menor ou igual a 0.");
        }
    }
}
