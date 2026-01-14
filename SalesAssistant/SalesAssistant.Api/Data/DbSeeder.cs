using SalesAssistant.Api.Models;

namespace SalesAssistant.Api.Data;

public static class DbSeeder
{
    public static void Seed(SalesAssistantDbContext context)
    {
        if (!context.Customers.Any())
        {
            context.Customers.Add(new Customer
            {
                FullName = "Cliente Demo",
                Email = "demo@cliente.com",
                Phone = "123456789"
            });
        }

        if (!context.Products.Any())
        {
            context.Products.AddRange(
                new Product
                {
                    Name = "Producto A",
                    Description = "Producto de prueba",
                    Price = 50,
                    Stock = 10
                },
                new Product
                {
                    Name = "Producto B",
                    Description = "Producto de prueba",
                    Price = 30,
                    Stock = 20
                }
            );
        }

        context.SaveChanges();
    }
}
