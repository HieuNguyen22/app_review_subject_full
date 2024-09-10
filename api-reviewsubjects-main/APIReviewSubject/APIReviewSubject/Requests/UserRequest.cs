namespace APIReviewSubject.Requests
{
    public class UserRequest
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string? email { get; set; }
        public string fullname { get; set; }
        public string avatar { get; set; }
        public int universityId { get; set; }
        public int facultyId { get; set; }
        public string? major { get; set; }
    }
}
