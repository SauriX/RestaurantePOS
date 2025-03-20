namespace RestaurantePOS.Dtos.UsersDtos
{
    public class UserListDto
    {
        public int Id_UserType { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserNickName { get; set; }
        public bool Active { get; set; }
        public string UserType { get; set; }
    }
}
