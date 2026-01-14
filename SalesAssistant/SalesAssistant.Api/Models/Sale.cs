namespace SalesAssistant.Api.Models
{
    public class Sale : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public decimal Total { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";

        // Navigation
        public Customer Customer { get; set; } = null!;
        public ICollection<SaleItem> Items { get; set; } = new List<SaleItem>();
        // Quién creó la venta
        public Guid CreatedByUserId { get; set; }

    }
}
