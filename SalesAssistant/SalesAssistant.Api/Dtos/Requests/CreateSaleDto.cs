namespace SalesAssistant.Api.Dtos.Requests
{
    public class CreateSaleDto
    {
        public Guid CustomerId { get; set; }
        public List<CreateSaleItemDto> Items { get; set; } = new();
    }
}
