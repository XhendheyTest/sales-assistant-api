using Microsoft.EntityFrameworkCore;
using SalesAssistant.Api.Data;
using SalesAssistant.Api.Dtos.Requests;
using SalesAssistant.Api.Dtos.Response;
using SalesAssistant.Api.Models;

namespace SalesAssistant.Api.Services;

public class ProductService : IProductService
{
    private readonly SalesAssistantDbContext _context;

    public ProductService(SalesAssistantDbContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(CreateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Stock = dto.Stock
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products
            .Where(p => p.IsActive)
            .ToListAsync();
    }

    public async Task<PagedResult<ProductResponseDto>> GetPagedAsync(
    PaginationParams pagination,
    string? search)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(p => p.Name.Contains(search));

        var total = await query.CountAsync();

        var items = await query
            .OrderBy(p => p.Name)
            .Skip((pagination.Page - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            })
            .ToListAsync();

        return new PagedResult<ProductResponseDto>
        {
            Page = pagination.Page,
            PageSize = pagination.PageSize,
            TotalRecords = total,
            Items = items
        };
    }
}
