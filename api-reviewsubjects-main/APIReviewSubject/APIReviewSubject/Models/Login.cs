namespace APIReviewSubject.Models
{
    public class Login
    {
        public string userName { get; set; }
        public string password { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public Login(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public Login() { }
    }
}
