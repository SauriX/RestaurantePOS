using Microsoft.EntityFrameworkCore;
using RestaurantePOS.context;
using RestaurantePOS.Domain.Users;
using RestaurantePOS.Migrations;
using RestaurantePOS.Respository.IRespository;

namespace RestaurantePOS.Respository
{
    public class UsersRepository:IUsersRepository
    {
        private readonly ContextDb _contextDb;
        
        public UsersRepository( ContextDb contextDb ) { 
            _contextDb = contextDb;
            
        }

        public async Task CreateUser(Users user)
        {
            _contextDb.Users.Add( user );
            await _contextDb.SaveChangesAsync();
        }

        public async Task<List<Users>> GetAll()
        {
            return await _contextDb.Users.Include(u=>u.UserType).ToListAsync();
        }

        public async Task<Users> GetByUserId(int userId)
        {
            var user = await _contextDb.Users.Include(u => u.UserType).FirstOrDefaultAsync( x => x.UserId == userId );
            return user;
        }
        public async Task<Users> GetByUserNickname(string ninckName)
        {
            var user = await _contextDb.Users.Include(u => u.UserType).FirstOrDefaultAsync(x => x.UserNickName.ToUpper() == ninckName.ToUpper());
            return user;
        }
        public async Task<bool> IsDuplicate(Users user)
        {
            var isDuplicate = await _contextDb.Users.AnyAsync(x => x.UserId != user.UserId && x.UserNickName.ToUpper() == user.UserNickName.ToUpper());
            return isDuplicate;
        }

        public async Task UpdateUser(Users user)
        {
            _contextDb.Users.Update( user );
           await _contextDb.SaveChangesAsync( );
        }
    }
}
