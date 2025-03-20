using Microsoft.AspNetCore.Mvc;
using RestaurantePOS.Domain.Configuration;
using RestaurantePOS.Dtos.UserTypeDtos;
using RestaurantePOS.Services;
using RestaurantePOS.Services.IServices;

namespace RestaurantePOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigurationsController:ControllerBase
    {
        private readonly IConfigurationsService _configurationsService;

        public ConfigurationsController(IConfigurationsService configurationsService) { 
            _configurationsService = configurationsService;
        }

        [HttpGet("{id}")]
        public async Task<Configurations> getConfig(int id)
        {
            return await _configurationsService.GetConfigurationAsync(id);
        }

        [HttpPut]
        public async Task<Configurations> Update(Configurations configurations)
        {
            return await _configurationsService.UpdateConfiguration(configurations);
        }
    }
}
