using RestaurantePOS.Dtos.CatecoriesDtos;
using RestaurantePOS.Helpers;
using RestaurantePOS.Mappers;
using RestaurantePOS.Respository.IRespository;
using RestaurantePOS.Services.IServices;
using System.Net;

namespace RestaurantePOS.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDiscuntRepository _discuntRepository;
        public CategoryService(ICategoryRepository categoryRepository, IDiscuntRepository discuntRepository) { 
            _categoryRepository = categoryRepository;
            _discuntRepository = discuntRepository;
        }

        public async Task<CategoriesListDto> AddCategory(CategoryFormDto category)
        {
            var categoryAdd = category.toModel();
            var isDuplicate = await _categoryRepository.IsDuplicated(categoryAdd);
            if (isDuplicate) {
                throw new CustomException(HttpStatusCode.Conflict,"Categoria ya Agregada");
            }
            await _categoryRepository.AddCategory(categoryAdd);
            if (categoryAdd.DiscuntId!=null) {
                var discunt = await _discuntRepository.getById(categoryAdd.DiscuntId??0);
                categoryAdd.Discount = discunt;
            }
            
            return categoryAdd.toCategoriesList();
        }

        public async Task<IEnumerable<CategoriesListDto>> getAllCategories()
        {
            var categories = await _categoryRepository.getAllCategories();
            return categories.toCategoriesList();
        }

        public async Task<IEnumerable<CategoriesListDto>> getCategoriesActive()
        {
            var categories = await _categoryRepository.getAllActiveCategories();
            return categories.toCategoriesList();
        }

        public async Task<CategoryFormDto> getCategoryById(int id)
        {
            var category = await _categoryRepository.getCategoryById(id);
            if (category == null)
            {
                throw new CustomException(HttpStatusCode.Conflict, "Categoria no encontrada");
            }
            return category.toCategoriesForm();
        }

        public async Task<CategoriesListDto> UpdateCategory(CategoryFormDto category)
        {
            var categoryOld = await _categoryRepository.getCategoryById(category.Id);
            if (categoryOld == null) {
                throw new CustomException(HttpStatusCode.Conflict, "Categoria no encontrada");
            }
            var categoryUpdate = category.toModel(categoryOld);
            var isDuplicate = await _categoryRepository.IsDuplicated(categoryUpdate);
            if (isDuplicate)
            {
                throw new CustomException(HttpStatusCode.Conflict, "Categoria ya Agregada");
            }
            await _categoryRepository.UpdateCategory(categoryUpdate);
            if (categoryUpdate.DiscuntId != null)
            {
                var discunt = await _discuntRepository.getById(categoryUpdate.DiscuntId ?? 0);
                categoryUpdate.Discount = discunt;
            }
            return categoryUpdate.toCategoriesList();
        }
    }
}
