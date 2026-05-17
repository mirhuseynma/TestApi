namespace TestApi.Domain.Models
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
