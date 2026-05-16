using Microsoft.EntityFrameworkCore;
using TestApi.Domain.Models;

namespace TestApi.Aplication.Common
{
    public interface IAppDbContext
    {
        public DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
