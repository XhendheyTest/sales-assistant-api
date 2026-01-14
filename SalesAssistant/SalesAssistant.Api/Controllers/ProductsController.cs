using Microsoft.AspNetCore.Mvc;
using SalesAssistant.Api.Dtos.Requests;
using SalesAssistant.Api.Dtos.Response;
using SalesAssistant.Api.Services;

namespace SalesAssistant.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        return Ok(await _service.CreateAsync(dto));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PagedResult<ProductResponseDto>>> GetPaged(
    [FromQuery] PaginationParams pagination,
    [FromQuery] string? search)
    {
        return Ok(await _service.GetPagedAsync(pagination, search));
    }
}
