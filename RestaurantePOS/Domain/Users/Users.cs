using System.Text.Json.Serialization;

namespace RestaurantePOS.Domain.Users
{
    public class Users
    {
        
        public int UserId { get; set; } 
        public string? UserName { get; set; }
        public string? UserNickName { get; set; }
        public string? Password { get; set; }
        public bool Active { get; set; } = true;
        public int Id_UserType { get; set; }
        public UserType UserType { get; set; }

    }
}
