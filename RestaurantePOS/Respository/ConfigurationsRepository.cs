using Microsoft.EntityFrameworkCore;
using RestaurantePOS.context;
using RestaurantePOS.Domain.Configuration;
using RestaurantePOS.Respository.IRespository;

namespace RestaurantePOS.Respository
{
    public class ConfigurationsRepository : IConfigurationsRepository
    {
        private readonly ContextDb _contextDb;
        public ConfigurationsRepository(ContextDb contextDb) {
            _contextDb = contextDb;
        }

        public async Task<Configurations> GetConfigurationAsync(int id)
        {
            var configuration = await _contextDb.Configurations.FirstOrDefaultAsync(c => c.Id == id);
            return configuration;
        }

        public async Task<Configurations> UpdateConfiguration(Configurations configuration)
        {
             _contextDb.Configurations.Update(configuration);
            await _contextDb.SaveChangesAsync();
            return configuration;
        }
    }
}
