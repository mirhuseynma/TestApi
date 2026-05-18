namespace TestApi.Aplication.Interfaces
{
    public interface IProductServices
    {
        Task<IEnumerable<GetProductWithCategoryDto>> GetProductsAsync();
        Task<GetProductWithCategoryDto> GetProductByIdAsync(int id);
        Task<GetProductWithCategoryDto> GetProductByNameAsync(string name);
        Task CreateProductAsync(ProductDto productDto);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(int id, ProductDto productDto);
    }
}
