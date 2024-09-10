using APIReviewSubject.Requests;
using System;

namespace APIReviewSubject.Models
{
    public class Like: BaseEntity
    {
        public int postId { get; set; }
        public int userId { get; set; }
        public Like(){}

        public Like(LikeRequest likeRequest)
        {
            postId = likeRequest.postId;
            userId = likeRequest.userId;
            status = 1;
            updated = DateTime.Now;
        }
    }
}
