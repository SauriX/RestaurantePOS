using RestaurantePOS.Domain.Users;
using RestaurantePOS.Dtos.UserTypeDtos;

namespace RestaurantePOS.Mappers
{
    public static class UserTypeMapper
    {
        public static IEnumerable<UserTypeListDto> ToUserTypeList(this IEnumerable<UserType> model)
        {
            if (model == null) return null;

            return model.Select(x => new UserTypeListDto { 
                IdUserType = x.Id_UserType,
                NameUserType = x.NameType,
            });
        }
        public static UserTypeListDto ToUserTypeList(this UserType model)
        {
            if (model == null) return null;

            return  new UserTypeListDto
            {
                IdUserType = model.Id_UserType,
                NameUserType = model.NameType,
            };
        }
        public static UserTypeFormDto ToUserTypeFormDto(this UserType userType) 
        {
            if (userType == null) return null;
            return new UserTypeFormDto { IdUserType = userType.Id_UserType, UserTypeName = userType.NameType}; 
        }

        public static UserType ToUserTypeModel(this UserTypeFormDto userType,UserType model) {
            if (model == null) return null;
            return new UserType 
            {
                Id_UserType = model.Id_UserType,
                NameType = userType.UserTypeName,
            };
        }

        public static UserType ToUserTypeModel(this UserTypeFormDto userType) 
        {
            if (userType == null) return null;
            return new UserType
            {
                NameType = userType.UserTypeName,
            };
        }
    }
}
    