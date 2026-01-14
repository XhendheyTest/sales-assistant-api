using SalesAssistant.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesAssistant.Api.Data
{
    public class SalesAssistantDbContext : DbContext
    {
        public SalesAssistantDbContext(DbContextOptions<SalesAssistantDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<SaleItem> SaleItems => Set<SaleItem>();
        public DbSet<AiConversation> AiConversations => Set<AiConversation>();
        public DbSet<AiMessage> AiMessages => Set<AiMessage>();
        public DbSet<User> Users => Set<User>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            // Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            // Sale
            modelBuilder.Entity<Sale>()
                .Property(s => s.Total)
                .HasPrecision(18, 2);

            // SaleItem
            modelBuilder.Entity<SaleItem>()
                .Property(si => si.UnitPrice)
                .HasPrecision(18, 2);

            // Customer
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            // Sale -> Customer
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

            // SaleItem -> Sale
            modelBuilder.Entity<SaleItem>()
                .HasOne(si => si.Sale)
                .WithMany(s => s.Items)
                .HasForeignKey(si => si.SaleId);

            // SaleItem -> Product
            modelBuilder.Entity<SaleItem>()
                .HasOne(si => si.Product)
                .WithMany()
                .HasForeignKey(si => si.ProductId);



            // AiConversation -> Customer
            modelBuilder.Entity<AiConversation>()
                .HasOne(ac => ac.Customer)
                .WithMany(c => c.AiConversations)
                .HasForeignKey(ac => ac.CustomerId);

            // AiMessage -> AiConversation
            modelBuilder.Entity<AiMessage>()
                .HasOne(am => am.Conversation)
                .WithMany(ac => ac.Messages)
                .HasForeignKey(am => am.ConversationId);
        }
    }
}
