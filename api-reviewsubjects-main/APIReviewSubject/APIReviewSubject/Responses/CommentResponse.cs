using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Data;
using System;

namespace APIReviewSubject.Responses
{
    public class CommentResponse
    {
        public Comment comment { get; set; }
        public string userFullname { get; set; }
        public string userAvatar { get; set; }
        public string postSubject { get; set; }
        public int countTime { get; set; }
        public int typeTime { get; set; }
        public string subject { get; set; }
        public string teacher { get; set; }

        public CommentResponse() { }

        /// <summary>
        /// Set Default Value
        /// </summary>
        public void SetDefault()
        {
            this.comment = new Comment();
            this.userFullname = "";
            this.userAvatar = "";
            this.postSubject = "";
            this.countTime = 0;
            this.typeTime = 0;
            this.subject = "";
            this.teacher = "";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comment"></param>
        public CommentResponse(Comment comment)
        {
            this.SetDefault();
            this.comment = comment;
            this.userAvatar = new UserRepository(new EntityContext()).GetEntityById(comment.userId).avatar;
            this.userFullname = new UserRepository(new EntityContext()).GetEntityById(comment.userId).fullname;
            this.postSubject = new PostRepository(new EntityContext()).GetEntityById(comment.postId).subject;
            TimeSpan temp = DateTime.Now.Subtract(comment.created);
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
    }
}
