using Microsoft.EntityFrameworkCore;
using TiendaIna.Core.Entities;

namespace TiendaIna.Web.Razor.Data
{
    public class TiendaInaWebRazorContext : DbContext
    {
        public TiendaInaWebRazorContext (DbContextOptions<TiendaInaWebRazorContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Brand> Brands { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;

       protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Product>()
             .HasMany(p => p.Categories)
             .WithMany(c => c.Products)
             .UsingEntity(j => j.ToTable("ProductsCategory")); // Nombre de la tabla intermedia

            modelBuilder.Entity<Product>()
             .HasOne(p => p.Brand)
             .WithMany(b => b.Products)
             .HasForeignKey(p => p.idBrand);

           base.OnModelCreating(modelBuilder);
        }

    }

}
