using Flunt.Validations;
using ReceiptAPI.Dtos.Request;

namespace ReceiptAPI.Validators
{
    public class ProductReceiptUpdateDtoContract : Contract<ProductReceiptUpdateDtoContract>
    {
        public ProductReceiptUpdateDtoContract(ProductReceiptUpdateDto productReceipt)
        {
            Requires()
                .IsGreaterThan(productReceipt.ProductId, 0, "productIdIsGreaterThan", "O id de um dos produtos não pode ser menor ou igual a 0.")
                .IsGreaterThan(productReceipt.Quantity, 0, "quantityIsGreaterThan", "A quantidade dos produtos selecionados não pode ser menor ou igual a 0.");
        }
    }
}
