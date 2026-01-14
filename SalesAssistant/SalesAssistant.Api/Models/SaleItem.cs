namespace SalesAssistant.Api.Models
{
    public class SaleItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal => Quantity * UnitPrice;

        // Navigation
        public Sale Sale { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
