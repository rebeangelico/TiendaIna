using Microsoft.EntityFrameworkCore;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Repos;
using TiendaIna.Infrastructure.Services;
using TiendaIna.Web.Razor.Data;

namespace TiendaIna.Web.Razor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //registro de vservios a falta de inyeccion de dependencias - AGREGAR LUEGO
            builder.Services.AddScoped<ICategoriesService, CategoriesService>();
            builder.Services.AddScoped<IProductsService, ProductsService>();
            builder.Services.AddScoped<InMemoryProductsRepo, ProductsRepo>();
            builder.Services.AddScoped<InMemoryCategoriesRepo, CategoriesRepo>();
            builder.Services.AddDbContext<TiendaInaWebRazorContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TiendaInaWebRazorContext") ?? throw new InvalidOperationException("Connection string 'TiendaInaWebRazorContext' not found.")));

            //package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore necesario
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore necesario
            else {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }

            //EJEMPLO DE LO QUE VAMOS A NECESITAR - REVISAR!!!

            /*
            using (var scope = app.Services.CreateScope()) {
                var services = scope.ServiceProvider;

                try {
                    var context = services.GetRequiredService<InventariosContext>();
                    context.Database.Migrate(); // Aplica migraciones pendientes automáticamente
                } catch (Exception ex) {
                    // Loguear el error o manejarlo como necesites
                    Console.WriteLine($"Error al aplicar migraciones: {ex.Message}");
                }
            }
            */

            //MODO MOMENTANEO DE DATOS SIN PRESERVACION PARA PRUEBAS Y DEMAS 
            using (var scope = app.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<TiendaInaWebRazorContext>();
                context.Database.EnsureCreated();

                //inicializa el contex con informacion inicial
                DbInitializer.Initialize(context);
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
