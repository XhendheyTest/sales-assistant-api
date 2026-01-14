namespace SalesAssistant.Api.Dtos.Response
{
    public class CustomerResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
