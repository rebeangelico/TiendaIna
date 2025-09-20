using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;
using RepoDb;
using TiendaIna.Admin.Blazor.Components;
using TiendaIna.Admin.Blazor.Components.Account;
using TiendaIna.Admin.Blazor.Data;
using TiendaIna.Core;

namespace TiendaIna.Admin.Blazor {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddRadzenComponents();

            builder.Services.AddHttpClient();
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();

            //configuracion RepoDb
            DependencyInjection.Configure(builder.Services, builder.Configuration);
            GlobalConfiguration.Setup().UseSqlServer();

            var app = builder.Build();

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
