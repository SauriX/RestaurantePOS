using RestaurantePOS.Domain.Users;
using RestaurantePOS.Dtos.UsersDtos;

namespace RestaurantePOS.Mappers
{
    public static class UserMapper
    {
        public static IEnumerable<UserListDto> toUserListDto(this IEnumerable<Users> users) {
            return users.Select(x=>new UserListDto { 
                Id_UserType = x.Id_UserType,
                UserId = x.UserId,
                UserName = x.UserName,
                UserNickName=x.UserNickName,
                Active = x.Active,
                UserType=x.UserType.NameType,
            });
        }

        public static UserListDto toUserListDto(this Users user)
        {
            return  new UserListDto
            {
                Id_UserType = user.Id_UserType,
                UserId = user.UserId,
                UserName = user.UserName,
                UserNickName = user.UserNickName,
                Active = user.Active,

            };
        }
        public static UserFormDto toUserForm(this Users user)
        {
            return new UserFormDto()
            {
                UserId = user.UserId ,
                UserName = user.UserName ,
                UserNickName = user.UserNickName ,
                Active = user.Active,
                Id_UserType= user.Id_UserType ,
            };
        }

        public static Users toUsersModel(this UserFormDto user)
        {
            return new Users()
            {
                
                UserName = user.UserName,
                UserNickName = user.UserNickName,
                Password = user.Password,
                Id_UserType = user.Id_UserType,
                Active = user.Active,
            };
        }

        public static Users toUsersModel(this UserFormDto user,Users model)
        {
            return new Users()
            {
                UserId = model.UserId,
                UserName = user.UserName,
                UserNickName = user.UserNickName,
                Password = model.Password,
                Id_UserType = user.Id_UserType,
                Active = user.Active,
            };
        }
    }
}
