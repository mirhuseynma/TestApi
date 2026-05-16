using TestApi.Domain.Models.Common;

namespace TestApi.Domain.Models
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
    }
}
