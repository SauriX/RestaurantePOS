using RestaurantePOS.Dtos.CatecoriesDtos;

namespace RestaurantePOS.Services.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoriesListDto>> getAllCategories();
        Task<IEnumerable<CategoriesListDto>> getCategoriesActive();
        Task<CategoryFormDto> getCategoryById(int id);
        Task<CategoriesListDto> AddCategory(CategoryFormDto category);
        Task<CategoriesListDto> UpdateCategory(CategoryFormDto category);
    }
}
