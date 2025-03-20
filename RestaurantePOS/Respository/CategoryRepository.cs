using Microsoft.EntityFrameworkCore;
using RestaurantePOS.context;
using RestaurantePOS.Domain.Catalogos;
using RestaurantePOS.Migrations;
using RestaurantePOS.Respository.IRespository;

namespace RestaurantePOS.Respository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ContextDb _contextDb;
        public CategoryRepository(ContextDb contextDb ) { 
            _contextDb = contextDb;
        }

        public async Task AddCategory(Categories category)
        {
            _contextDb.Categories.Add(category);
            await _contextDb.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categories>> getAllActiveCategories()
        {
            var categories =   _contextDb.Categories.Include(d=>d.Discount).AsQueryable();
            var categoriesActives = categories.Where(category=> category.Active); 

            return categoriesActives;
        }

        public async Task<IEnumerable<Categories>> getAllCategories()
        {
            var categories = await _contextDb.Categories.Include(d => d.Discount).ToArrayAsync();
            return categories;
        }

        public async Task<Categories> getCategoryById(int id)
        {
            var category = await _contextDb.Categories.Include(d => d.Discount).FirstOrDefaultAsync(categorie => categorie.Id==id);
            return category;
        }

        public async Task<bool> IsDuplicated(Categories category)
        {
            var isDuplicate = await _contextDb.Categories.Include(d => d.Discount).AnyAsync(catego => catego.Id != category.Id && catego.Name == category.Name);
            return isDuplicate;
        }

        public async Task UpdateCategory(Categories category)
        {
            _contextDb.Update(category);
            await _contextDb.SaveChangesAsync();
        }
    }
}
