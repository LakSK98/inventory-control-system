using AutoMapper;
using InventoryControlSystem.DTOs;
using InventoryControlSystem.Models;
using InventoryControlSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _productCategoryRepository.GetAllCategoriesAsync();
            var categoryDtos = _mapper.Map<List<ProductCategoryDTO>>(categories);
            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _productCategoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDto = _mapper.Map<ProductCategoryDTO>(category);
            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(ProductCategoryDTO categoryDto)
        {
            var category = _mapper.Map<ProductCategory>(categoryDto);
            await _productCategoryRepository.AddCategoryAsync(category);

            var createdCategoryDto = _mapper.Map<ProductCategoryDTO>(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategoryDto.CategoryId }, createdCategoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, ProductCategoryDTO categoryDto)
        {
            var existingCategory = await _productCategoryRepository.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            _mapper.Map(categoryDto, existingCategory);

            await _productCategoryRepository.UpdateCategoryAsync(existingCategory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _productCategoryRepository.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
