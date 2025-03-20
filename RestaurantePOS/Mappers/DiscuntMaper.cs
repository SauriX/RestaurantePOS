using RestaurantePOS.Domain.Configuration;
using RestaurantePOS.Dtos.DiscuntsDto;

namespace RestaurantePOS.Mappers
{
    public static class DiscuntMaper
    {
        public static IEnumerable<DiscuntListDto> toDiscuntList(this IEnumerable<Discunts> discunts) {
            return discunts.Select(discunt => new DiscuntListDto() { 
                DiscuntId = discunt.DiscuntId,
                DiscuntName = discunt.DiscuntName,
                Active= discunt.Active?"Activo":"Desactivado",
                Porcent= $"{discunt.Porcent} %",
            });
        }
        public static DiscuntListDto toDiscuntList(this Discunts discunt)
        {
            return new DiscuntListDto()
            {
                DiscuntId = discunt.DiscuntId,
                DiscuntName = discunt.DiscuntName,
                Active = discunt.Active ? "Activo" : "Desactivado",
                Porcent = $"{discunt.Porcent} %",
            };
        }

        public static DiscuntFormDto toDiscuntForm(this Discunts discunt) {
            return new DiscuntFormDto()
            {
                Active = discunt.Active,
                Porcent = discunt.Porcent,
                DiscuntId = discunt.DiscuntId,
                DiscuntName = discunt.DiscuntName,
            };
        }

        public static Discunts toModel(this DiscuntFormDto discunt) {
            return new Discunts()
            {
                Active = discunt.Active,
                Porcent = discunt.Porcent,
                DiscuntName = discunt.DiscuntName,
            };
        }


        public static Discunts toModel(this DiscuntFormDto discunt,Discunts model)
        {
            return new Discunts()
            {
                Active = discunt.Active,
                Porcent = discunt.Porcent,
                DiscuntId = model.DiscuntId,
                DiscuntName = discunt.DiscuntName,
            };
        }
    }
}
