using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantePOS.Domain.Users;
using System.Reflection.Emit;

namespace RestaurantePOS.context.EntityConfiguration.UserTypes
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
       

        void IEntityTypeConfiguration<UserType>.Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasKey(x => x.Id_UserType);
            builder.Property(x => x.Id_UserType).ValueGeneratedOnAdd();
            
        }
    }
}
