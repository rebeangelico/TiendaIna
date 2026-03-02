using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TiendaIna.Core.Models;
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

            services.AddScoped<ICartsService, CartsService>();

            services.AddScoped<IClientsService, ClientsService>();
            services.AddScoped<IPaymentsService, PaymentsService>();
            services.AddScoped<IProductsInfoService, ProductsInfoService>();
            services.AddScoped<IOrdersService, OrdersService>();

            var inMemoryRepos = bool.Parse(configuration.GetSection("InMemoryRepos").Value ?? false.ToString());
            if (inMemoryRepos) {
                services.AddScoped<IProductsRepo, ProductsInMemoryRepo>();
                services.AddScoped<IProductImagesRepo, ProductImagesInMemoryRepo>();
                services.AddScoped<ICategoriesRepo, CategoriesInMemoryRepo>();
                services.AddScoped<IBrandsRepo, BrandsInMemoryRepo>();
                services.AddScoped<IImagesRepo, ImagesInMemoryRepo>();

                services.AddScoped<IOrdersRepo, OrdersInMemoryRepo>();
                services.AddScoped<IClientsRepo, ClientsInMemoryRepo>();
                services.AddScoped<IPaymentsRepo, PaymentsInMemoryRepo>();
                services.AddScoped<IProductsInfoRepo, ProductsInfoInMemoryRepo>();
                

                //in-memory stores (only for local testing)
                services.AddSingleton<IInMemoryProductsStore, InMemoryProductsStore>();
                services.AddSingleton<IInMemoryProductsCategoriesStore, InMemoryProductsCategoriesStore>();
                services.AddSingleton<IInMemoryProductImagesStore, InMemoryProductImagesStore>();
                services.AddSingleton<IInMemoryCategoriesStore, InMemoryCategoriesStore>();
                services.AddSingleton<IInMemoryBrandsStore, InMemoryBrandsStore>();
                services.AddSingleton<IInMemoryImagesStore, InMemoryImagesStore>();
           
                services.AddSingleton<IInMemoryOrdersStore, InMemoryOrdersStore>();
                services.AddSingleton<IInMemoryClientsStore, InMemoryClientsStore>();
                services.AddSingleton<IInMemoryPaymentsStore, InMemoryPaymentsStore>();
                services.AddSingleton<IInMemoryProductsInfoStore, InMemoryProductsInfoStore>();
                
            }
            else {
                services.AddScoped<IProductsRepo, ProductsDbRepo>();
                services.AddScoped<IProductImagesRepo, ProductImagesDbRepo>();
                services.AddScoped<ICategoriesRepo, CategoriesDbRepo>();
                services.AddScoped<IBrandsRepo, BrandsDbRepo>();
                services.AddScoped<IImagesRepo, ImagesDbRepo>();
                services.AddScoped<IClientsRepo, ClientsDbRepo>();
                services.AddScoped<IPaymentsRepo, PaymentsDbRepo>();
                services.AddScoped<IProductsInfoRepo, ProductsInfoDbRepo>();
                services.AddScoped<IOrdersRepo, OrdersDbRepo>();
            }
        }
    }
}
