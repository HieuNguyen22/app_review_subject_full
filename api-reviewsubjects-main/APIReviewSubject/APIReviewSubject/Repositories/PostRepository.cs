using APIReviewSubject.Data;
using APIReviewSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIReviewSubject.Repositories
{
    public class PostRepository : BaseRepository<Post>
    {
        public PostRepository(EntityContext ctx) : base(ctx)
        {
        }

        /// <summary>
        /// Disable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Disable(int id)
        {
            Post post = GetEntityById(id);
            post.status = 2;
            return UpdateEntity(id, post);
        }

        /// <summary>
        /// Enable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Enable(int id)
        {
            Post post = GetEntityById(id);
            post.status = 1;
            return UpdateEntity(id, post);
        }

        /// <summary>
        /// Update Point
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pointFix"></param>
        public void UpdatePoint(int id, int fix)
        {
            Post post = GetEntityById(id);
            post.point += fix;
            UpdateEntity(id, post);
        }

        /// <summary>
        /// Update LikeCount
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fix"></param>
        public void UpdateLikeCount(int id, int fix)
        {
            Post post = GetEntityById(id);
            post.likeCount += fix;
            UpdateEntity(id, post);
        }

        /// <summary>
        /// Update CommentCount
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fix"></param>
        public void UpdateCommentCount(int id, int fix)
        {
            Post post = GetEntityById(id);
            post.commentCount += fix;
            UpdateEntity(id, post);
        }

        /// <summary>
        /// Get posts by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Post> GetByUserId(int userId)
        {
            return Model.Where(p => p.userId == userId).ToList();
        }

        /// <summary>
        /// Get List Posts By FacultyId By Page
        /// </summary>
        /// <param name="facultyId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<Post> GetByFacultyId(int facultyId)
        {
            return Model.Where(p => p.facultyId == facultyId).ToList();
        }

        /// <summary>
        /// Get By university Id
        /// </summary>
        /// <param name="universityId"></param>
        /// <returns></returns>
        public List<Post> GetByUniversityId(int universityId)
        {
            return Model.Where(p => p.universityId == universityId).ToList();
        }

        /// <summary>
        /// Get By Key Search 
        /// </summary>
        /// <param name="keySearch"></param>
        /// <returns></returns>
        public List<Post> GetByKeySearch(string keySearch)
        {
            return Model.Where(p => p.subject.ToLower().Contains(keySearch.ToLower()))
                .OrderBy(p => p.subject).ToList();
        }
    }
}
