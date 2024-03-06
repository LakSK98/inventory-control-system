using AutoMapper;
using InventoryControlSystem.DTOs;
using InventoryControlSystem.Models;
using InventoryControlSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            var ProductDTOs = _mapper.Map<List<ProductDTO>>(products);
            return Ok(ProductDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var ProductDTO = _mapper.Map<ProductDTO>(product);
            return Ok(ProductDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO ProductDTO)
        {
            var product = _mapper.Map<Product>(ProductDTO);
            await _productRepository.AddProductAsync(product);

            var createdProductDTO = _mapper.Map<ProductDTO>(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProductDTO.ProductId }, createdProductDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO ProductDTO)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _mapper.Map(ProductDTO, existingProduct);

            await _productRepository.UpdateProductAsync(existingProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
