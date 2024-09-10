namespace APIReviewSubject.Models
{
    public class Admin : BaseEntity
    {
        public string userName { get; set; }
        public string password { get; set; }

        public Admin() { }
    }
}
