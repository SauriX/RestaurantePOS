namespace RestaurantePOS.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RestaurantePOS.context;

    using RestaurantePOS.Domain.Users;

    [ApiController]
    [Route("api/[controller]")]
    public class MiController : ControllerBase
    {
        private readonly ContextDb _context;

        public MiController(ContextDb context)
        {
            _context = context;
        }



        [HttpGet("Users")]
        public async Task<ActionResult<IEnumerable<UserType>>> GetUsers()
        {
            return await _context.UserTypes.ToListAsync();
        }
    }

}
