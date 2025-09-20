using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using RepoDb;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services {
    public class CategoriesRepoDbService : ICategoriesService {
        private readonly string _connectionString;

        public CategoriesRepoDbService(IConfiguration configuration) {
            _connectionString = "Server=localhost,1433;Database=TiendaIna;User Id=sa;Password=Rebe2025;TrustServerCertificate=true";
        }

        public int InsertCategory(string name, int? parentId = null) {
            using var connection = new SqlConnection(_connectionString);
            var category = new Category {
                Name = name,
                ParentCategoryId = parentId
            };

            var result = connection.Insert<Category>(category);
            return Convert.ToInt32(result);
        }

        public IEnumerable<Category> GetAllCategories() {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryAll<Category>();
        }
        public Category? GetCategoryById(int id) {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Category>(c => c.Id == id).FirstOrDefault();
        }


        public Task<List<CategoryModel>> GetCategories() {
            throw new NotImplementedException();
        }

        public Task<CategoryModel> GetCategory(int categoryId) {
            throw new NotImplementedException();
        }

        public Task AddCategory(CategoryModel category) {
            throw new NotImplementedException();
        }

        public Task UpdateCategory(CategoryModel category) {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(int categoryId) {
            throw new NotImplementedException();
        }
    }
}
