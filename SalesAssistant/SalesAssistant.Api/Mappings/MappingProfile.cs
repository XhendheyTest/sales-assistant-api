using AutoMapper;
using SalesAssistant.Api.Dtos.Response;
using SalesAssistant.Api.Models;

namespace SalesAssistant.Api.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Customer
            CreateMap<Customer, CustomerResponseDto>();

            // Product
            CreateMap<Product, ProductResponseDto>();

            // SaleItem → DTO
            CreateMap<SaleItem, SaleItemResponseDto>()
                .ForMember(dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Product!.Name))
                .ForMember(dest => dest.SubTotal,
                    opt => opt.MapFrom(src => src.Quantity * src.UnitPrice));

            // Sale → DTO
            CreateMap<Sale, SaleResponseDto>();
        }
    }
}