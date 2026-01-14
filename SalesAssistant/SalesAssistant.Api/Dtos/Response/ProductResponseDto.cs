namespace SalesAssistant.Api.Dtos.Response
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
