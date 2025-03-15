using RestaurantePOS.Dtos.UserTypeDtos;

namespace RestaurantePOS.Services.IServices
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserTypeListDto>> GetAllUserTypes();
        Task<UserTypeFormDto> GetUserTypeById(int id);
        Task<UserTypeListDto> CreateUserType(UserTypeFormDto userTypeFormDto);
        Task<UserTypeListDto> UpdateUserType(UserTypeFormDto UserTypeFormDto);
    }
}
