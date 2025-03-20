using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantePOS.Domain.Catalogos;

namespace RestaurantePOS.context.EntityConfiguration.Catalgos
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder
            .HasOne(c => c.Discount)
            .WithMany()  // No se define la relación inversa en Discount
            .HasForeignKey(c => c.DiscuntId)
            .OnDelete(DeleteBehavior.SetNull); 
        }
    }
}
