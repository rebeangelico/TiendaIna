using Microsoft.Extensions.DependencyInjection;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure;
using TiendaIna.Infrastructure.Repos;
using TiendaIna.Infrastructure.Services;

namespace TiendaIna.Core {
    public static class DependencyInjections {

        public static void Configure(this IServiceCollection services) {
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IProductsRepo, ProductsInMemoryRepo>();

            //in-memory stores (only for local testing)
            services.AddSingleton<IInMemoryProductsStore, InMemoryProductsStore>();
        }
    }
}
