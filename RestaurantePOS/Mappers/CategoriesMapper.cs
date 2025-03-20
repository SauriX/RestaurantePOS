using RestaurantePOS.Domain.Catalogos;
using RestaurantePOS.Dtos.CatecoriesDtos;
using RestaurantePOS.Migrations;

namespace RestaurantePOS.Mappers
{
    public static class CategoriesMapper
    {
        public static IEnumerable<CategoriesListDto> toCategoriesList(this IEnumerable<Categories> categories) {
            return categories.Select(category => new CategoriesListDto()
            {
                Id = category.Id,
                Name = category.Name,
                Discunt = $"{category.Discount?.Porcent ?? 0}%",
                Active = category.Active?"Activo":"Desactivado"
                
            });
        }
        public static CategoriesListDto toCategoriesList(this Categories category) {
            return new CategoriesListDto()
            {
                Id = category.Id,
                Name = category.Name,
                Discunt = $"{category.Discount?.Porcent ?? 0}%",
                Active = category.Active ? "Activo" : "Desactivado"
            };
        }

        public static CategoryFormDto toCategoriesForm(this Categories categories) { 
            return new CategoryFormDto() 
            { 
                Name = categories.Name,
                Id = categories.Id,
                 Active = categories.Active,
                DiscuntId = categories.DiscuntId
            };
        
        }
        public static Categories toModel(this CategoryFormDto categories) {
            return new Categories()
            {
                Name = categories.Name,
                Active = categories.Active,
                DiscuntId = categories.DiscuntId==0?null:categories.DiscuntId
            };
        }
        public static Categories toModel(this CategoryFormDto categories,Categories model) {

            return new Categories()
            {
                Id= model.Id,
                Name = categories.Name,
                Active = categories.Active,
                DiscuntId = categories.DiscuntId == 0 ? null : categories.DiscuntId
            };
        }
    }
}
