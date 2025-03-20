using Microsoft.AspNetCore.Mvc;
using RestaurantePOS.Dtos.CatecoriesDtos;
using RestaurantePOS.Services.IServices;

namespace RestaurantePOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController:ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) { 
            _categoryService = categoryService;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<CategoriesListDto>> getAll() { 
           return await _categoryService.getAllCategories();
        }
        [HttpGet("actives")]
        public async Task<IEnumerable<CategoriesListDto>> getAllActive()
        {
            return await _categoryService.getCategoriesActive();
        }
        [HttpGet("{id}")]
        public async Task<CategoryFormDto> getById(int id)
        {
            return await _categoryService.getCategoryById(id);
        }
        [HttpPost]
        public async Task<CategoriesListDto> Add(CategoryFormDto categoryFormDto) { 
                return await _categoryService.AddCategory(categoryFormDto);
        }

        [HttpPut]
        public async Task<CategoriesListDto> Update(CategoryFormDto categoryFormDto) { 
            return await _categoryService.UpdateCategory(categoryFormDto);
        }
    }
}
