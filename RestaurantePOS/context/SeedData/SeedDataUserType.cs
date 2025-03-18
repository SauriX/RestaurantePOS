using RestaurantePOS.Domain.Users;

namespace RestaurantePOS.context.SeedData
{
    public class SeedDataUserType
    {
        // Tipos de usuario
        public static List<UserType> GetUserType()
        {
            var UserType = new List<UserType>()
            {
                new UserType(1, "Administrador"),
                new UserType(2, "Vendedor"),
                new UserType(3, "REPARTIDOR" ),

            };

            return UserType;
        }
    }
}
