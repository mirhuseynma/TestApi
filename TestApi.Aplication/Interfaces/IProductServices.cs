namespace TestApi.Aplication.Interfaces
{
    public interface IProductServices
    {
        Task<IEnumerable<GetProductDto>> GetProductsAsync();
        Task<GetProductDto> GetProductByIdAsync(int id);
        Task<GetProductDto> GetProductByNameAsync(string name);
        Task CreateProductAsync(ProductDto productDto);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(int id, ProductDto productDto);
    }
}
