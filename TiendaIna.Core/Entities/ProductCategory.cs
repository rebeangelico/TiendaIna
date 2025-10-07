using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaIna.Core.Entities;

[Table("ProductsCategories")]
public class ProductCategory {
    public int ProductId { get; set; }
    public int CategoryId { get; set; }

    public ProductCategory(int productId, int categoryId) {
        this.ProductId = productId;
        this.CategoryId = categoryId;
    }
}
