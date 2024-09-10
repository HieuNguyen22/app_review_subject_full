using APIReviewSubject.Data;
using APIReviewSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIReviewSubject.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>
    {
        public NotificationRepository(EntityContext ctx) : base(ctx)
        {
        }

        /// <summary>
        /// Get By PostId
        /// </summary>
        /// <param name="postId"></param>
        public List<Notification> GetByPostId(int postId)
        {
            return Model.Where(like => like.postId == postId).ToList();
        }

        /// <summary>
        /// Get By Id Comment
        /// </summary>
        /// <param name="commentId"></param>
        public List<Notification> GetByCommentId(int commentId)
        {
            return Model.Where(not => not.commentId == commentId).ToList();
        }

        /// <summary>
        ///  Check Notification Exist
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userBId"></param>
        /// <param name="type"></param>
        /// <param name="postId"></param>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public int NotificationExist(int userId, int userBId, int type, int postId, int commentId)
        {
            var arr = Model.FirstOrDefault(x => x.userId == userId &&
                                                x.userBId == userBId &&
                                                x.type == type &&
                                                x.postId == postId &&
                                                x.commentId == commentId);
            if (arr != null) return arr.id;
            return 0;
        }

        /// <summary>
        /// Get List Notifications
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<Notification> GetNotifications(int userId)
        {
            return Model.Where(n => n.userId == userId)
                .OrderBy(n => n.created)
                .Reverse()
                .ToList();
        }
    }
}
