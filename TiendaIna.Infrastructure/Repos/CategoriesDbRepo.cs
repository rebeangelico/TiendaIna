using Microsoft.Extensions.Options;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos {
    public class CategoriesDbRepo : DbRepoBase<Category, int>, ICategoriesRepo {

        public CategoriesDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) {
        }

        public Task Add(Category category) {
            Create(category);
            return Task.CompletedTask;
        }

        public Task Delete(int id) {
            DeleteEntity(id); 
            return Task.CompletedTask;
        }

        public Task<Category> GetAsync(int id) {
            var result = GetById(id); 
            return Task.FromResult(result);
        }

        public Task Update(Category category) {
            UpdateEntity(category); 
            return Task.CompletedTask;
        }

        Task<List<Category>> ICategoriesRepo.GetAllAsync() {
            var result = GetAllAsync().ToList(); 
            return Task.FromResult(result);
        }
    }
}
