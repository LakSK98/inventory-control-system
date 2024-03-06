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
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
