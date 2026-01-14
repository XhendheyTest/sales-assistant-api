namespace SalesAssistant.Api.Models
{
    public class AiMessage
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ConversationId { get; set; }
        public string Role { get; set; } = null!; // User | Assistant
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public AiConversation Conversation { get; set; } = null!;
    }
}
