using SalesAssistant.Api.Dtos.Requests;
using SalesAssistant.Api.Models;

namespace SalesAssistant.Api.Services
{
    public interface ICustomerService
    {
        Task<Customer> CreateAsync(CreateCustomerDto dto);
        Task<List<Customer>> GetAllAsync();
    }
}
