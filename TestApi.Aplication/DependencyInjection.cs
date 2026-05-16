
namespace TestApi.Aplication
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(DependencyInjection).Assembly));

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
