using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Application.Repositories.Product;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        // private readonly IProductService _productService;
        //
        // public ProductsController(IProductService productService)
        // {
        //     _productService = productService;
        // }
        //
        // [HttpGet]
        // public IActionResult GetProducts()
        // {
        //     var products = _productService.GetProducts();
        //     return Ok(products);
        // }

        [HttpGet]
        public async Task Get()
        {
            // await _productWriteRepository.AddRangeAsync(new()
            // {
            //     new(){ Id = Guid.NewGuid(), Name = "Product 4", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10},
            //     new(){ Id = Guid.NewGuid(), Name = "Product 5", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20},
            //     new(){ Id = Guid.NewGuid(), Name = "Product 6", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 30},
            // });
            // await _productWriteRepository.SaveAsync();
            
            Product p = await _productReadRepository.GetByIdAsync("c05efc83-437f-4ce1-939e-183eaaab3e89");
            p.Name = "Product 7";
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
 