using APIReviewSubject.Data;
using APIReviewSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIReviewSubject.Repositories
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(EntityContext ctx) : base(ctx)
        {
        }

        /// <summary>
        /// Get By PostId
        /// </summary>
        /// <param name="postId"></param>
        public List<Comment> GetByPostId(int postId)
        {
            return Model.Where(cmt => cmt.postId == postId).ToList();
        }

        /// <summary>
        /// Get By User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Comment> GetByUserId(int userId)
        {
            return Model.Where(cmt => cmt.userId == userId).ToList();
        }

        /// <summary>
        /// Get By Key Search
        /// </summary>
        /// <param name="keySearch"></param>
        /// <returns></returns>
        public List<Comment> GetByKeySearch(string keySearch)
        {
            return Model.Where(c => c.content.ToLower().Contains(keySearch.ToLower())).ToList();
        }

        /// <summary>
        /// Disable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Disable(int id)
        {
            Comment comment = GetEntityById(id);
            comment.status = 2;
            return UpdateEntity(id, comment);
        }

        /// <summary>
        /// Enable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Enable(int id)
        {
            Comment comment = GetEntityById(id);
            comment.status = 1;
            return UpdateEntity(id, comment);
        }
    }
}
