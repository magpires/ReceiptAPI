namespace ReceiptAPI.Dtos.Response
{
    public class ProductReceiptDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantitity { get; set; }
        public double Total { get; set; }
    }
}
