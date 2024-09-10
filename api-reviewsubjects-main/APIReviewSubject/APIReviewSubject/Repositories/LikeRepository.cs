using APIReviewSubject.Data;
using APIReviewSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIReviewSubject.Repositories
{
    public class LikeRepository : BaseRepository<Like>
    {
        public LikeRepository(EntityContext ctx) : base(ctx)
        {
        }

        /// <summary>
        /// Get By Post Id
        /// </summary>
        /// <param name="postId"></param>
        public List<Like> GetByPostId(int postId)
        {
            return Model.Where(like => like.postId == postId).ToList();
        }

        /// <summary>
        /// check likepost exist
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int LikePostExist(int postId, int userId)
        {
            var arr = Model.Where(l => l.postId == postId && l.userId == userId).ToList();
            if (arr.Any()) return arr.ElementAt(0).id;
            return 0;
        }
    }
}
