
namespace TestApi.Aplication.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public ProductServices(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateProductAsync(ProductDto productDto)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Name == productDto.ProductName);
            if (existingProduct != null) throw new Exception("A product with the same name already exists.");
            

            var product = _mapper.Map<Product>(productDto);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) throw new Exception("Product not found.");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<GetProductDto> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) throw new Exception("Product not found.");
            return _mapper.Map<GetProductDto>(product);
        }

        public async Task<GetProductDto> GetProductByNameAsync(string name)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
            if (product == null) throw new Exception("Product not found.");
            return _mapper.Map<GetProductDto>(product);
        }

        public async Task<IEnumerable<GetProductDto>> GetProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            if (products.Count == 0) throw new Exception("No products found.");
            return products.Select(p => _mapper.Map<GetProductDto>(p));
        }

        public async    Task UpdateProductAsync(int id, ProductDto productDto)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null) throw new Exception("Product not found.");

            existingProduct.Id = id;
            if (productDto.ProductName != null) existingProduct.Name = productDto.ProductName;
            if (productDto.ProductDescription != null) existingProduct.Description = productDto.ProductDescription;
            if ( productDto.ProductPrice >= 0) existingProduct.Price = productDto.ProductPrice;

            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();
        }
    }
}