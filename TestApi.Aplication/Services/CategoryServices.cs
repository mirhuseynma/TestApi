namespace TestApi.Aplication.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IMapper _mapper;
        private readonly IAppDbContext _context;
        public CategoryServices(IMapper mapper, IAppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateAsync(CreateCategoryDto dto)
        {
            var existingCategory = _context.Categories.FirstOrDefault(c => c.Name == dto.CategoryName);
            if(existingCategory != null) throw new Exception("Category with the same name already exists.");
            
            var category = _mapper.Map<Category>(dto);
            if(category != null)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
            }
            throw new Exception("Failed to create category.");
        }

        public async Task DeleteAsync(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            throw new Exception("Category not found.");
        }

        public async Task<IEnumerable<GetCategoryWithProductsDto>> GetAllAsync()
        {
            var categories = await _context.Categories.Include(c => c.Products).Where(c => !c.IsDeleted).ToListAsync();
            var categoryDtos = _mapper.Map<List<GetCategoryWithProductsDto>>(categories);
            if (categoryDtos != null) return categoryDtos;
            throw new Exception("No categories found.");
        }

        public async Task<GetCategoryWithProductsDto> GetByIdAsync(int id)
        {
            var category = await _context.Categories.Include(c => c.Products).Where(c => !c.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
            if(category != null) return _mapper.Map<GetCategoryWithProductsDto>(category);
            
            throw new Exception("Category not found.");
        }

        public async Task<GetCategoryWithProductsDto> GetByNameAsync(string name)
        {
            var category = await _context.Categories.Include(c => c.Products).Where(c => !c.IsDeleted).FirstOrDefaultAsync(x => x.Name == name);
            if(category != null) return _mapper.Map<GetCategoryWithProductsDto>(category);
            throw new Exception("Category not found.");
        }

        public async Task UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var category = await _context.Categories.Where(c => !c.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
            if(category != null)
            {
                if (dto.Name != null)
                {
                    var existingCategory = _context.Categories.FirstOrDefault(c => c.Name == dto.Name);
                    if (existingCategory != null && existingCategory.Id != id)
                        throw new Exception("Another category with the same name already exists.");
                }
                _mapper.Map(dto, category);
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
            }
            throw new Exception("Category not found.");
        }
    }
}
