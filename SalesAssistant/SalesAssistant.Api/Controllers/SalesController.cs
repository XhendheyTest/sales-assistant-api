using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesAssistant.Api.Dtos.Requests;
using SalesAssistant.Api.Dtos.Response;
using SalesAssistant.Api.Services;

namespace SalesAssistant.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Seller")]
public class SalesController : ControllerBase
{
    private readonly ISaleService _saleService;


    public SalesController(ISaleService saleService)
    {
        _saleService = saleService;
    }



   
    [HttpPost]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleDto dto)
    {
        try
        {

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var sale = await _saleService.CreateSaleAsync(dto,userId);
            return Ok(sale);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
   
    public async Task<IActionResult> GetSales()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var sales = await _saleService.GetAllAsync(userId);
        return Ok(sales);
    }

   
}
