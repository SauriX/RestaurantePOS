using RestaurantePOS.Dtos.UserTypeDtos;
using RestaurantePOS.Helpers;
using RestaurantePOS.Helpers.Dictionary;
using RestaurantePOS.Mappers;
using RestaurantePOS.Respository.IRespository;
using RestaurantePOS.Services.IServices;
using System.Net;

namespace RestaurantePOS.Services
{
    public class UserTypeService: IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;
        public UserTypeService(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public async Task<IEnumerable<UserTypeListDto>> GetAllUserTypes()
        {

            var userTypes = await _userTypeRepository.GetAll();

            return userTypes.ToUserTypeList();
        }

        public async Task<UserTypeFormDto> GetUserTypeById(int id)
        {
            var UserType = await _userTypeRepository.GetByUsertypeId(id);
                
            return UserType.ToUserTypeFormDto();
        }

        public async Task<UserTypeListDto> CreateUserType(UserTypeFormDto userTypeFormDto)
        {
            var newUserTypeForm = userTypeFormDto.ToUserTypeModel();

            var isDuplicated = await _userTypeRepository.IsDuplicate(newUserTypeForm);

            if (isDuplicated)
            {
                throw new CustomException(HttpStatusCode.Conflict, "Resgitro Duplicado");
            }

            await _userTypeRepository.CreateUserType(newUserTypeForm);

            return newUserTypeForm.ToUserTypeList();
        }

        public async Task<UserTypeListDto> UpdateUserType(UserTypeFormDto UserTypeFormDto)
        {
            var existing = await _userTypeRepository.GetByUsertypeId(UserTypeFormDto.IdUserType);
            if (existing == null) {
                throw new CustomException(HttpStatusCode.NotFound, Responses.NotFound);
            }

            var updateUserType = UserTypeFormDto.ToUserTypeModel(existing);
            var isDuplicated = await _userTypeRepository.IsDuplicate(updateUserType);

            if (isDuplicated)
            {
                throw new CustomException(HttpStatusCode.Conflict, "Resgitro Duplicado");
            }

            await _userTypeRepository.UpdateUserType(updateUserType);

            return updateUserType.ToUserTypeList();
        }
    }
}
