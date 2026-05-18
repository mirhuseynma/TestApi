namespace TestApi.Aplication.DTOs.Categories
{
    public class GetCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

    }

    public class GetCategoryWithProductsDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public List<GetProductDto> Products { get; set; } = new List<GetProductDto>();
    }
}
