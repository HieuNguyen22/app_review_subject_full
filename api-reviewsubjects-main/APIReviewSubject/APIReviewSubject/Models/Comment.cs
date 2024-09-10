using APIReviewSubject.Requests;
using System;

namespace APIReviewSubject.Models
{
    public class Comment : BaseEntity
    {
        public int userId { get; set; }
        public int postId { get; set; }
        public string content { get; set; }
        public Comment(){}

        public Comment(CommentRequest commentRequest)
        {
            userId = commentRequest.userId;
            postId = commentRequest.postId;
            content = commentRequest.content;
            status = 1;
            updated = DateTime.Now;
        }
    }
}