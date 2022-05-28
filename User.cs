namespace DisneyAPI
{
    public class User
    {
       
        public string UserMail { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }    

        public byte[] PasswordSalt { get; set; }    

       
    }
}
