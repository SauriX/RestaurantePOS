using RestaurantePOS.context.SeedData;

namespace RestaurantePOS.context
{
    public class Seed
    {
        public static async Task SeedTables(ContextDb context, bool update)
        {
            //UserType
            if (!context.UserTypes.Any()) {
                var userTypes = SeedDataUserType.GetUserType();
                context.AddRange(userTypes);
                await context.SaveChangesAsync();
            }
        }
    }
}
