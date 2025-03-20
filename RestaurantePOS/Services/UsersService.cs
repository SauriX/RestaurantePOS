using Azure;
using Microsoft.IdentityModel.Tokens;
using RestaurantePOS.Domain.Users;
using RestaurantePOS.Dtos.UsersDtos;
using RestaurantePOS.Helpers;
using RestaurantePOS.Mappers;
using RestaurantePOS.Respository.IRespository;
using RestaurantePOS.Services.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace RestaurantePOS.Services
{
    public class UsersService:IUsersServices
    {
        private readonly IUsersRepository _usersRepository;
        private readonly string _secretKey;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UsersService(IUsersRepository usersRepository, IConfiguration configuration,IHttpContextAccessor httpContextAccessor) {
            _usersRepository = usersRepository;
            _secretKey = configuration["Secrets:SecretKey"];
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserListDto> CreateUser(UserFormDto user)
        {
            var userNew = user.toUsersModel();
            var isDuplicated = await _usersRepository.IsDuplicate(userNew);
            if (isDuplicated)
            {
                throw new CustomException(HttpStatusCode.Conflict, "Resgitro Duplicado");
            }
            userNew.Password = Encryption.GetBcrypt(user.Password);
            await _usersRepository.CreateUser(userNew);
            return userNew.toUserListDto();

        }

        public async Task<IEnumerable<UserListDto>> GetAll()
        {
            var users = await _usersRepository.GetAll();
            return users.toUserListDto();
        }

        public async Task<UserFormDto> GetByUserId(int userId)
        {
            var user = await _usersRepository.GetByUserId(userId);
            return user.toUserForm();
        }

        public async Task<string> GetByUserNickname(UserLogin userLogin)
        {
            var user = await _usersRepository.GetByUserNickname(userLogin.UserNickName);
            if (user == null || !user.Active) {
                throw new CustomException(HttpStatusCode.NotFound, "Usuario no encontrado");
            }

            if (!Encryption.IsValidPassword(userLogin.Password,user.Password))
            {
                throw new CustomException(HttpStatusCode.Conflict, "Contraseña incorrecta");
            }
            var key = Encryption.DeriveKey(_secretKey);
            if (key.Length < 32)
            {
                throw new CustomException(HttpStatusCode.InternalServerError, "La clave debe tener al menos 256 bits.");
            }

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Id_UserType.ToString()),
                    new Claim("UserId", user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                // Acceder a HttpContext y agregar la cookie
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext != null)
                {
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = false, // No accesible desde JS (previene XSS)
                        Secure = true, // Solo en HTTPS
                        SameSite = SameSiteMode.None, // Previene CSRF
                        Expires = DateTime.UtcNow.AddHours(2) // Expira en 2 horas
                    };

                    httpContext.Response.Cookies.Append("AuthToken", tokenString, cookieOptions);
                }

                return tokenString;
            }
            catch (Exception e)
            {

                throw new CustomException(HttpStatusCode.InternalServerError, e.StackTrace);
            }


        }


        public async Task<UserListDto> UpdateUser(UserFormDto user)
        {
            var userModel = await _usersRepository.GetByUserId(user.UserId);
            var isDuplicated = await _usersRepository.IsDuplicate(userModel);
            
            if (isDuplicated)
            {
                throw new CustomException(HttpStatusCode.Conflict, "Resgitro Duplicado");
            }
            var users = await _usersRepository.GetAll();
            var activeAdmins = users.Where(x => x.Active && x.Id_UserType == 1).ToList();

            // Verifica si solo queda un admin activo y si el usuario que se quiere modificar es el último admin
            if (activeAdmins.Count == 1 && activeAdmins[0].UserId == userModel.UserId && !user.Active && user.Id_UserType == 1)
            {
                throw new CustomException(HttpStatusCode.Conflict, "No se puede modificar este usuario, ya que es el único administrador activo.");
            }
            var userupdate = user.toUsersModel(userModel);
            if (!string.IsNullOrEmpty(user.Password)) {
                userupdate.Password = Encryption.GetBcrypt(user.Password);
            }
            await _usersRepository.UpdateUser(userupdate);
            return userupdate.toUserListDto();
        }
    }
}
