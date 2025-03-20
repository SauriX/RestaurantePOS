using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantePOS.Dtos.UsersDtos;
using RestaurantePOS.Services.IServices;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantePOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {   
        private readonly IUsersServices _usersService;

        public UserController(IUsersServices usersService) { 
            _usersService = usersService;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<UserListDto>> getAll(){
            return await _usersService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<UserFormDto> getById(int id)
        {
            return await _usersService.GetByUserId(id);
        }
        [HttpPost]
        public async Task<UserListDto> create(UserFormDto user) { 
            return await _usersService.CreateUser(user);
        } 

        [HttpPut]
        public async Task<UserListDto> update(UserFormDto user)
        {
            return await _usersService.UpdateUser(user);
        }
        [HttpPost("login")]
        public async Task<string> Login(UserLogin user) {
            return await _usersService.GetByUserNickname(user);
        }

        [HttpGet("info")]
        [Authorize]
        public IActionResult GetSecretData()
            {
            var token = Request.Cookies["AuthToken"];  // Obtener el token desde la cookie

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(); // Si no hay token, denegar acceso
            }

            // Aquí puedes proceder con la validación y decodificación del token JWT si es necesario

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var username = User.Identity.Name;  // Obtén el nombre de usuario del Claim

            return Ok(new
            {
                UserId = userId,
                Username = username,
                Role = role
            });
        }
    }
}
