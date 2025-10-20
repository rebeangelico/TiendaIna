using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.DataStore;
using TiendaIna.Infrastructure.Repos;
using TiendaIna.Infrastructure.Services;

namespace TiendaIna.Core {
    public static class DependencyInjection {

        public static void Configure(IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IBrandsService, BrandsService>();
            services.AddScoped<IImagesService, ImagesService>();
            services.AddScoped<IProductImagesService, ProductImagesService>();

            services.AddScoped<IProductsRepo, ProductsInMemoryRepo>();
            services.AddScoped<IProductImagesRepo, ProductImagesInMemoryRepo>();
            services.AddScoped<ICategoriesRepo, CategoriesInMemoryRepo>();
            services.AddScoped<IBrandsRepo, BrandsInMemoryRepo>();
            services.AddScoped<IImagesRepo, ImagesInMemoryRepo>();

            //in-memory stores (only for local testing)
            services.AddSingleton<IInMemoryProductsStore, InMemoryProductsStore>();
            services.AddSingleton<IInMemoryProductsCategoriesStore, InMemoryProductsCategoriesStore>();
            services.AddSingleton<IInMemoryProductImagesStore, InMemoryProductImagesStore>();
            services.AddSingleton<IInMemoryCategoriesStore, InMemoryCategoriesStore>();
            services.AddSingleton<IInMemoryBrandsStore, InMemoryBrandsStore>();
            services.AddSingleton<IInMemoryImagesStore, InMemoryImagesStore>();
        }
    }
}
