namespace TestApi.Aplication.DTOs.Products
{
    public class ProductDto
    {
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public decimal ProductPrice { get; set; } 
        public IFormFile ProductImage { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
