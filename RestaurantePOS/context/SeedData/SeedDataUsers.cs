using RestaurantePOS.Domain.Users;
using RestaurantePOS.Helpers;

namespace RestaurantePOS.context.SeedData
{
    public class SeedDataUsers
    {
        public static Users getUser()
        {
            return new Users()
            {
                Id_UserType = 1,
                UserName = "Test",
                UserNickName = "Test",
                Password = Encryption.GetBcrypt("1"),
            };
        }
    }
}
