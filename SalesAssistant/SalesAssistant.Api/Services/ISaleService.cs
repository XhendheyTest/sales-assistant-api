using System.Threading.Tasks;
using SalesAssistant.Api.Dtos.Requests;
using SalesAssistant.Api.Dtos.Response;
using SalesAssistant.Api.Models;

namespace SalesAssistant.Api.Services
{
    public interface ISaleService
    {
        Task<SaleResponseDto> CreateSaleAsync(CreateSaleDto dto, Guid UserId);
        Task<List<SaleResponseDto>> GetAllAsync(Guid userId);

    }
}