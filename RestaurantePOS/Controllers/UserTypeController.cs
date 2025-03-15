using Microsoft.AspNetCore.Mvc;
using RestaurantePOS.Dtos.UserTypeDtos;
using RestaurantePOS.Services.IServices;

namespace RestaurantePOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;
        public UserTypeController(IUserTypeService userTypeService) {
            _userTypeService = userTypeService;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<UserTypeListDto>>getAll(){
            return await _userTypeService.GetAllUserTypes();
        }

        [HttpGet("{id}")]
        public async Task<UserTypeFormDto> getById(int id)
        {
            return await _userTypeService.GetUserTypeById(id);
        }

        [HttpPost]
        public async Task<UserTypeListDto>create(UserTypeFormDto userTypeFormDto)
        {
            return await _userTypeService.CreateUserType(userTypeFormDto);
        }

        [HttpPut]
        public async Task<UserTypeListDto> update(UserTypeFormDto userTypeFormDto) 
        {
            return await _userTypeService.UpdateUserType(userTypeFormDto);
        }
    }
}
