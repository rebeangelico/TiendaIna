using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure;
using TiendaIna.Infrastructure.Repos;
using TiendaIna.Infrastructure.Services;

namespace TiendaIna.Core {
    public static class DependencyInjection {

        public static void Configure(IServiceCollection services, IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("SqlServer");


            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IProductsRepo, ProductsInMemoryRepo>();
            services.AddScoped<ICategoriesRepo>(provider => new CategoriesDbRepo(connectionString));


            //in-memory stores (only for local testing)
            services.AddSingleton<IInMemoryProductsStore, InMemoryProductsStore>();
            services.AddSingleton<IInMemoryCategoriesStore, InMemoryCategoriesStore>();
        }
    }
}
