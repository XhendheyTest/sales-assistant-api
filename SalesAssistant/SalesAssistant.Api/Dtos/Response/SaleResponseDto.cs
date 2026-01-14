namespace SalesAssistant.Api.Dtos.Response
{
    public class SaleResponseDto
    {
        public Guid Id { get; set; }
        public decimal Total { get; set; }
        public DateTime SaleDate { get; set; }

        public CustomerResponseDto Customer { get; set; } = null!;
        public List<SaleItemResponseDto> Items { get; set; } = new();
    }
}
