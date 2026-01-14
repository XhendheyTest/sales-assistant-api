namespace SalesAssistant.Api.Dtos.Requests
{
    public class CreateCustomerDto
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
