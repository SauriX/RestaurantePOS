using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantePOS.Domain.Users;

namespace RestaurantePOS.context.EntityConfiguration
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x=>x.UserId);
            builder.Property(x=>x.UserId).ValueGeneratedOnAdd();
            builder.HasOne(e => e.UserType)
                .WithOne().HasForeignKey<Users>(x=>x.Id_UserType)
                .IsRequired();
        }
    }
}
