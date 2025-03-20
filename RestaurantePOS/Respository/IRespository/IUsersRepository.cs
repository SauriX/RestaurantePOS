using RestaurantePOS.Domain.Users;

namespace RestaurantePOS.Respository.IRespository
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetAll();
        Task<Users> GetByUserId(int userId);
        Task CreateUser(Users user);
        Task UpdateUser(Users user);
        Task<bool> IsDuplicate(Users user);
        Task<Users> GetByUserNickname(string ninckName);
    }
}
