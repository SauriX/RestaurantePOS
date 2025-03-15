using RestaurantePOS.Domain.Users;

namespace RestaurantePOS.Respository.IRespository
{
    public interface IUserTypeRepository
    {
        Task<List<UserType>> GetAll();
        Task<UserType> GetByUsertypeId(int UserTypeId);
        Task CreateUserType(UserType userType);
        Task UpdateUserType(UserType userType);
        Task<bool> IsDuplicate(UserType userType);
    }
}
