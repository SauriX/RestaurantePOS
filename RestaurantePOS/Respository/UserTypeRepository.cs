using Microsoft.EntityFrameworkCore;
using RestaurantePOS.context;
using RestaurantePOS.Domain.Users;
using RestaurantePOS.Helpers;
using RestaurantePOS.Respository.IRespository;

namespace RestaurantePOS.Respository
{
    public class UserTypeRepository:IUserTypeRepository
    {
        private readonly ContextDb _contextDb;
        public UserTypeRepository( ContextDb contextDb) { 
            _contextDb = contextDb;
        }

        public async Task<List<UserType>> GetAll()
        {
            return await _contextDb.UserTypes.ToListAsync();
        }

        public async Task<UserType> GetByUsertypeId(int UserTypeId) {

            var UserType = await _contextDb.UserTypes.FirstOrDefaultAsync(u=>u.Id_UserType==UserTypeId);
            return UserType;
        }

        public async Task CreateUserType(UserType userType)
        {
            _contextDb.UserTypes.Add(userType);
            await _contextDb.SaveChangesAsync();
        }

        public async Task UpdateUserType(UserType userType)
        {
            try
            {
 

                _contextDb.UserTypes.Update(userType);

                await _contextDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Loguear el error
                throw new CustomException(System.Net.HttpStatusCode.BadGateway, ex.Message);
            }

        }

        public async Task<bool> IsDuplicate(UserType userType) {
            var isDuplicate = await _contextDb.UserTypes.AnyAsync(x=> x.Id_UserType!= userType.Id_UserType && x.NameType == userType.NameType);

            return isDuplicate;
        }
    }
}
