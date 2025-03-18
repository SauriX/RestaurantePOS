namespace RestaurantePOS.Domain.Users
{
    public class UserType
    {


        public UserType(int Id_UserType, string NameType)
        {
            this.Id_UserType = Id_UserType;
            this.NameType = NameType;
        }
        public UserType()
        {
    
        }
        public int Id_UserType { get; set; }
        public string NameType { get; set; }

    }
}
