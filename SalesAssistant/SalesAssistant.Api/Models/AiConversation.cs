namespace SalesAssistant.Api.Models
{
    public class AiConversation : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? EndedAt { get; set; }
        public string Channel { get; set; } = "Web";

        // Navigation
        public Customer Customer { get; set; } = null!;
        public ICollection<AiMessage> Messages { get; set; } = new List<AiMessage>();
    }
}
