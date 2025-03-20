
using RestaurantePOS.Dtos.UsersDtos;

namespace RestaurantePOS.Services.IServices
{
    public interface IUsersServices
    {
        Task<IEnumerable<UserListDto>> GetAll();
        Task<UserFormDto> GetByUserId(int userId);
        Task<UserListDto> CreateUser(UserFormDto user);
        Task<UserListDto> UpdateUser(UserFormDto user);
        Task<string> GetByUserNickname(UserLogin userLogin);
    }
}
