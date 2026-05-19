using Microsoft.Extensions.Configuration;

namespace TestApi.Aplication
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(DependencyInjection).Assembly));

            services.AddValidatorsFromAssembly(assembly);

            // Load the persistence assembly dynamically
            var persistenceAssemblyPath = Path.Combine(AppContext.BaseDirectory, "TestApi.Persistence.dll");
            if (File.Exists(persistenceAssemblyPath))
            {
                var persistenceAssembly = Assembly.LoadFrom(persistenceAssemblyPath);
                var extensionType = persistenceAssembly.GetType("TestApi.Persistence.DependencyInjection");
                var addPersistenceMethod = extensionType?.GetMethod("AddPersistence");

                if (addPersistenceMethod != null)
                {
                    addPersistenceMethod.Invoke(null, new object[] { services, configuration });
                }
            }

            return services;
        }
    }
}
