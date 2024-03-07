using AutoMapper;
using InventoryControlSystem.DTOs;
using InventoryControlSystem.Models;

namespace InventoryControlSystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDTO>();
            CreateMap<ProductCategoryDTO, ProductCategory>();
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : null))
                .ForSourceMember(src => src.Category, opt => opt.DoNotValidate());
            CreateMap<ProductDTO, Product>();
        }
    }
}
