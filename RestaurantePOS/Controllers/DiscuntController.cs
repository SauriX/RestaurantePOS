using Microsoft.AspNetCore.Mvc;
using RestaurantePOS.Dtos.DiscuntsDto;
using RestaurantePOS.Services.IServices;

namespace RestaurantePOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscuntController : ControllerBase
    {
        private readonly IDiscuntService _discuntService;
        public DiscuntController(IDiscuntService discuntService)
        {
            _discuntService = discuntService;
        }
        [HttpGet("all")]
        public async Task<IEnumerable<DiscuntListDto>> getAll()
        {
            return await _discuntService.getAll();
        }

        [HttpGet("{id}")]
        public async Task<DiscuntFormDto> getById(int id)
        {
            return await _discuntService.getById(id);
        }

        [HttpPost]
        public async Task<DiscuntListDto> AddDiscunt(DiscuntFormDto discunt)
        {
            return await _discuntService.addDiscunt(discunt);
        }

        [HttpPut]
        public async Task<DiscuntListDto> UpdateDicunt(DiscuntFormDto discunt)
        {
            return await _discuntService.updateDiscunt(discunt);
        }
    }
}
