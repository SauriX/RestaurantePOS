using RestaurantePOS.Domain.Catalogos;

namespace RestaurantePOS.Respository.IRespository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Categories>> getAllCategories();
        Task<IEnumerable<Categories>> getAllActiveCategories();
        Task<Categories> getCategoryById(int id);
        Task AddCategory(Categories category);
        Task UpdateCategory(Categories category);
        Task <bool> IsDuplicated(Categories category);
    }
}
