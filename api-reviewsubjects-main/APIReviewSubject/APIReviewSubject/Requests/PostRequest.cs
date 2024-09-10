namespace APIReviewSubject.Requests
{
    public class PostRequest
    {
        public string subject { get; set; }
        public string teacher { get; set; }
        public int universityId { get; set; }
        public int facultyId { get; set; }
        public string? major { get; set; }
        public string? document { get; set; }
        public int rateHard { get; set; }
        public string? reviewHard { get; set; }
        public int rateLike { get; set; }
        public string? reviewLike { get; set; }
        public int rateExam { get; set; }
        public string? reviewExam { get; set; }
        public int userId { get; set; }
    }
}
