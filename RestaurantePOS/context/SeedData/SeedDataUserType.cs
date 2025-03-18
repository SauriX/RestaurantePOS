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
                new UserType( "Administrador"),
                new UserType( "Vendedor"),
                new UserType( "REPARTIDOR" ),

            };

            return UserType;
        }
    }
}
