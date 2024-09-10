using System;

namespace APIReviewSubject.Requests
{
    public class CommentRequest
    {
        public int userId { get; set; }
        public int postId { get; set; }
        public string content { get; set; }
    }
}
