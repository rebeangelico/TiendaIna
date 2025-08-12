using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos {
    public class ProductsInMemoryRepo : IProductsRepo {

        #region Readonly Products
        private readonly IInMemoryProductsStore _products;
        #endregion

        
        public ProductsInMemoryRepo(IInMemoryProductsStore products) {
            _products = products ?? throw new ArgumentNullException(nameof(products));
        }

        public Task AddProduct(Product product) {
            if (_products.Any(p => p.Id == product.Id))
                throw new InvalidOperationException($"Ya existe un producto con ID {product.Id}");

            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task DeleteProduct(int productId) {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new KeyNotFoundException($"No se encontró el producto con ID {productId}");

            _products.Remove(product);
            return Task.CompletedTask;
        }


        public async Task<Product> GetProduct(int productId) => (await GetProductsAsync()).Single(p => p.Id == productId);

        public Task<List<Product>> GetProductsAsync() {
            return Task.FromResult((List<Product>)_products);
        }

        public Task UpdateProduct(Product product) {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "El producto no puede ser nulo.");
            var existingProduct = _products.SingleOrDefault(p => p.Id == product.Id);
            if (existingProduct is null)
                throw new KeyNotFoundException($"No se encontró el producto con ID {product.Id}");
            var existingIndex = _products.IndexOf(existingProduct);
            _products.RemoveAt(existingIndex);
            _products.Insert(existingIndex, product);
            return Task.CompletedTask;
        }


    }
}