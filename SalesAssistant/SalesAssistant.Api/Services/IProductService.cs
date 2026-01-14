using SalesAssistant.Api.Dtos.Requests;
using SalesAssistant.Api.Dtos.Response;
using SalesAssistant.Api.Models;

namespace SalesAssistant.Api.Services;

public interface IProductService
{
    Task<Product> CreateAsync(CreateProductDto dto);
    Task<List<Product>> GetAllAsync();

    Task<PagedResult<ProductResponseDto>> GetPagedAsync(
       PaginationParams pagination,
       string? search);
}
