
namespace TestApi.Aplication.Interfaces
{
    public interface ICategoryServices
    {
        Task<GetCategoryWithProductsDto> GetByIdAsync(int id);
        Task<GetCategoryWithProductsDto> GetByNameAsync(string name);
        Task<IEnumerable<GetCategoryWithProductsDto>> GetAllAsync();
        Task CreateAsync(CreateCategoryDto dto);
        Task UpdateAsync(int id, UpdateCategoryDto dto);    
        Task DeleteAsync(int id);
    }
}
