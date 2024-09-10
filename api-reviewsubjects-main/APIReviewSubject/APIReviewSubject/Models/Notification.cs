namespace APIReviewSubject.Models
{
    public class Notification : BaseEntity
    {
        public int userId { get; set; }
        public int userBId { get; set; }
        public int postId { get; set; }
        public int commentId { get; set; }
        public int type { get; set; }
        public bool isReaded { get; set; }
        public Notification() {}
    }
}
