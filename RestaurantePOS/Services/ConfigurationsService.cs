using RestaurantePOS.Domain.Configuration;
using RestaurantePOS.Respository.IRespository;
using RestaurantePOS.Services.IServices;

namespace RestaurantePOS.Services
{
    public class ConfigurationsService:IConfigurationsService
    {
        private readonly IConfigurationsRepository _configurationsRepository;
        public ConfigurationsService(IConfigurationsRepository configurationsRepository) {
            _configurationsRepository = configurationsRepository;
        }

        public async Task<Configurations> GetConfigurationAsync(int id)
        {
            return await _configurationsRepository.GetConfigurationAsync(id);
        }

        public async Task<Configurations> UpdateConfiguration(Configurations configuration)
        {
            return await _configurationsRepository.UpdateConfiguration(configuration);
        }
    }
}
