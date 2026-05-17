namespace TestApi.Aplication.Common
{
    public interface IAppDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
