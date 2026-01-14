namespace SalesAssistant.Api.Dtos.Response
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
