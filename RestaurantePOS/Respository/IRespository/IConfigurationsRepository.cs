using RestaurantePOS.Domain.Configuracion;

namespace RestaurantePOS.Respository.IRespository
{
    public interface IConfigurationsRepository
    {
        Task<Configurations> GetConfigurationAsync(int id);
        Task<Configurations> UpdateConfiguration(Configurations configuration);

    }
}
