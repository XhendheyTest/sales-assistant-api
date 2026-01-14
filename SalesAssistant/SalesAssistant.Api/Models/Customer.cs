namespace SalesAssistant.Api.Models
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }

        // Navigation
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public ICollection<AiConversation> AiConversations { get; set; } = new List<AiConversation>();
    }
}
