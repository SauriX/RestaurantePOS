using RestaurantePOS.Domain.Configuration;

namespace RestaurantePOS.Domain.Catalogos
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int? DiscuntId { get; set; }
        public Discunts? Discount { get; set; }  // Propiedad de navegación opcional

    }
}
