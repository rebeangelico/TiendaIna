using Microsoft.EntityFrameworkCore;
using Radzen;
using RepoDb;
using TiendaIna.Admin.Blazor.Components;
using TiendaIna.Core;
using TiendaIna.Core.Models;

namespace TiendaIna.Admin.Blazor {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddRadzenComponents();

            builder.Services.AddHttpClient();
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
                app.UseMigrationsEndPoint();
            } else {
                app.UseExceptionHandler("/Error");
            }

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
