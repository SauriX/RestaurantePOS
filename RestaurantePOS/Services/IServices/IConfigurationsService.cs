using RestaurantePOS.Domain.Configuration;

namespace RestaurantePOS.Services.IServices
{
    public interface IConfigurationsService
    {
        Task<Configurations> GetConfigurationAsync(int id);
        Task<Configurations> UpdateConfiguration(Configurations configuration);
    }
}
