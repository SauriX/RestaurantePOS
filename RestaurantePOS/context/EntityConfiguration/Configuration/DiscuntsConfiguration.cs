using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantePOS.Domain.Configuration;

namespace RestaurantePOS.context.EntityConfiguration.Configuration
{
    public class DiscuntsConfiguration : IEntityTypeConfiguration<Discunts>
    {
        public void Configure(EntityTypeBuilder<Discunts> builder)
        {
            builder.HasKey(x => x.DiscuntId);
            builder.Property(x => x.DiscuntId).ValueGeneratedOnAdd();
            builder.Property(x=>x.Porcent).HasPrecision(0);
        }
    }
}
