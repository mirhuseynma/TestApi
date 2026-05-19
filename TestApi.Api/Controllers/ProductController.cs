using Microsoft.AspNetCore.Mvc;
using TestApi.Aplication.Common;
using TestApi.Aplication.DTOs.Products;
using TestApi.Aplication.Interfaces;
using TestApi.Aplication.Services;
using TestApi.Infrastructure.Services;

namespace TestApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        
        private readonly IAppDbContext _context;
        private readonly IProductServices _services;

        public ProductController(IAppDbContext appDbContext, IProductServices productServices)
        {
            _context = appDbContext;
            _services = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _services.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _services.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var product = await _services.GetProductByNameAsync(name);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] ProductDto product)
        {
            await _services.CreateProductAsync(product);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductDto product)
        {
            await _services.UpdateProductAsync(id, product);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
