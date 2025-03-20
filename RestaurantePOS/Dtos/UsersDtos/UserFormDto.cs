namespace RestaurantePOS.Dtos.UsersDtos
{
    public class UserFormDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserNickName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public int Id_UserType { get; set; }
    }
}
