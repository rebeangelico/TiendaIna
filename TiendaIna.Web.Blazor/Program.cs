using Radzen;
using RepoDb;
using TiendaIna.Web.Blazor.Components;
using TiendaIna.Core;
using TiendaIna.Core.Models;
using TiendaIna.Infrastructure.Services;
using TiendaIna.Core.Services;

namespace TiendaIna.Web.Blazor {
    public static class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddRadzenComponents();

            builder.Services.AddHttpClient();
            builder.Services.AddScoped<ICategoriesService, CategoriesService>();
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();

            //configuracion RepoDb
            builder.Services.Configure<AppSettings>(builder.Configuration);
            DependencyInjection.Configure(builder.Services, builder.Configuration);
            GlobalConfiguration.Setup().UseSqlServer();

            var app = builder.Build();
            app.MapControllers();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
            }

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
