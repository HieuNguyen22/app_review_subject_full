using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIReviewSubject.Responses
{
    public class PostResponse
    {
        public Post post { get; set; }
        public int activeCommentCount { get; set; }
        public string userFullname { get; set; }
        public string userAvatar { get; set; }
        public string universityName { get; set; }
        public string facultyName { get; set; }
        public bool isLiked { get; set; }
        public int countTime { get; set; }
        public int typeTime { get; set; }

        public PostResponse() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="post"></param>
        /// <param name="userId"></param>
        public PostResponse(Post post, int userId)
        {
            this.SetDefault();
            EntityContext context = new EntityContext();
            this.post = post;
            this.activeCommentCount = new CommentRepository(context).GetByPostId(post.id).Where(c => c.status == 1).Count();
            this.universityName = new UniversityRepository(context).GetEntityById(post.universityId).name;
            this.userAvatar = new UserRepository(context).GetEntityById(post.userId).avatar;
            this.facultyName = new FacultyRepository(context).GetEntityById(post.facultyId).name;
            this.isLiked =  new LikeRepository(context).LikePostExist(post.id, userId) != 0;
            this.userFullname = new UserRepository(context).GetEntityById(post.userId).fullname;

            TimeSpan temp = DateTime.Now.Subtract(post.created);
            if (temp.TotalMinutes <= 60)
            {
                this.countTime = (int)temp.TotalMinutes;
                this.typeTime = 1;
            }
            else
            {
                if (temp.TotalHours <= 24)
                {
                    this.countTime = (int)temp.TotalHours;
                    this.typeTime = 2;
                }
                else
                {
                    this.countTime = (int)temp.TotalDays;
                    this.typeTime = 3;
                }
            }
        }

        /// <summary>
        /// Set Default Value
        /// </summary>
        public void SetDefault()
        {
            this.activeCommentCount = 0;
            this.userFullname = "";
            this.userFullname = "";
            this.userAvatar = "";
            this.universityName = "";
            this.facultyName = "";
            this.post = new Post();
            this.countTime = 0;
            this.typeTime = 0;
            this.isLiked = false;
        }
       
    }
}
