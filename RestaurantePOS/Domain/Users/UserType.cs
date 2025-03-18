namespace RestaurantePOS.Domain.Users
{
    public class UserType
    {


        public UserType( string NameType)
        {
            
            this.NameType = NameType;
        }
        public UserType()
        {
    
        }
        public int Id_UserType { get; set; }
        public string NameType { get; set; }

    }
}
