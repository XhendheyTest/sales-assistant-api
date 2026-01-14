using Microsoft.EntityFrameworkCore;
using SalesAssistant.Api.Data;
using SalesAssistant.Api.Dtos.Requests;
using SalesAssistant.Api.Models;

namespace SalesAssistant.Api.Services;

public class CustomerService : ICustomerService
{
    private readonly SalesAssistantDbContext _context;

    public CustomerService(SalesAssistantDbContext context)
    {
        _context = context;
    }

    public async Task<Customer> CreateAsync(CreateCustomerDto dto)
    {
        if (await _context.Customers.AnyAsync(c => c.Email == dto.Email))
            throw new Exception("Email ya registrado");

        var customer = new Customer
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Phone = dto.Phone
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return customer;
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers
            .Where(c => c.IsActive)
            .ToListAsync();
    }
}

