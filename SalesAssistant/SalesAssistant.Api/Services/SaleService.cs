using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesAssistant.Api.Data;
using SalesAssistant.Api.Dtos.Requests;
using SalesAssistant.Api.Dtos.Response;
using SalesAssistant.Api.Models;

namespace SalesAssistant.Api.Services;

public class SaleService : ISaleService
{
    private readonly SalesAssistantDbContext _context;
    private readonly IMapper _mapper;

    public SaleService(SalesAssistantDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SaleResponseDto> CreateSaleAsync(CreateSaleDto dto, Guid userId)
    {
        // 1️ Validar cliente
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == dto.CustomerId);
        if (customer is null) throw new Exception("Cliente no válido");

        // 2️ Crear venta
        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id,
            SaleDate = DateTime.UtcNow,
            CreatedByUserId = userId
        };

        // 3️ Procesar items
        foreach (var item in dto.Items)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == item.ProductId);
            if (product is null) throw new Exception("Producto no válido");
            if (product.Stock < item.Quantity) throw new Exception($"Stock insuficiente para {product.Name}");

            product.Stock -= item.Quantity;

            sale.Items.Add(new SaleItem
            {
                ProductId = product.Id,
                Quantity = item.Quantity,
                UnitPrice = product.Price
            });
        }

        // 4️ Calcular total
        sale.Total = sale.Items.Sum(i => i.Quantity * i.UnitPrice);

        // 5️ Guardar
        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();

        // 6️ Recargar con Includes
        var saleFromDb = await _context.Sales
            .Include(s => s.Customer)
            .Include(s => s.Items)
                .ThenInclude(i => i.Product)
            .FirstAsync(s => s.Id == sale.Id);

        // 7️ Mapear a DTO de respuesta
        return _mapper.Map<SaleResponseDto>(saleFromDb);
    }

    public async Task<List<SaleResponseDto>> GetAllAsync(Guid userId)
    {
        // Filtramos por usuario autenticado
        var sales = await _context.Sales
            .Include(s => s.Customer)
            .Include(s => s.Items)
                .ThenInclude(i => i.Product)
            .Where(s => s.CreatedByUserId == userId)
            .OrderByDescending(s => s.SaleDate)
            .ToListAsync();

        return _mapper.Map<List<SaleResponseDto>>(sales);
    }
}
