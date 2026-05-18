using Microsoft.AspNetCore.Mvc;
using TestApi.Aplication.Common;
using TestApi.Aplication.DTOs.Categories;
using TestApi.Aplication.Interfaces;

namespace TestApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IAppDbContext _context;
        private readonly ICategoryServices _services;

        public CategoryController(IAppDbContext appDbContext, ICategoryServices categoryServices)
        {
            _context = appDbContext;
            _services = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _services.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _services.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var category = await _services.GetByNameAsync(name);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDto dto)
        {
            await _services.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCategoryDto dto)
        {
            await _services.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteAsync(id);
            return Ok();
        }
    }
}
