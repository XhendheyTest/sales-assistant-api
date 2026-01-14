namespace SalesAssistant.Api.Dtos.Response
{
    public class SaleItemResponseDto
    {
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
    }
}
