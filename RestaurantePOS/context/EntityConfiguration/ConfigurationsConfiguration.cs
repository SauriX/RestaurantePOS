using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantePOS.Domain.Configuracion;

namespace RestaurantePOS.context.EntityConfiguration
{
    public class ConfigurationsConfiguration : IEntityTypeConfiguration<Configurations>
    {
        public void Configure(EntityTypeBuilder<Configurations> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
