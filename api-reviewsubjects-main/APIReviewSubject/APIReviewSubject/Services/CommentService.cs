using System;
using System.Collections.Generic;
using System.Linq;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Requests;

namespace APIReviewSubject.Services
{
    public class CommentService
    {
        private readonly CommentRepository commentRepository;
        private readonly NotificationRepository notificationRepository;
        private readonly PostRepository postRepository;
        private readonly UserRepository userRepository;

        /// <summary>
        /// Constructor CommentsController
        /// </summary>
        /// <param name="context"></param> 
        public CommentService(EntityContext context)
        {
            this.commentRepository = new CommentRepository(context);
            this.notificationRepository = new NotificationRepository(context);
            this.postRepository = new PostRepository(context);
            this.userRepository = new UserRepository(context);
        }

        /// <summary>
        /// Edit Comment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commentRequest"></param>
        /// <returns></returns>
        public Comment EditComment(int id, CommentRequest commentRequest, int userId)
        {
            try
            {
                if (!commentRepository.EntityExist(id) || commentRequest.userId != userId)
                    return new Comment();

                Comment comment = new Comment(commentRequest);
                comment.id = id;
                comment.created = commentRepository.GetEntityById(id).created;

                commentRepository.UpdateEntity(id, comment);
                return comment;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Create new Comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public Comment Create(CommentRequest commentRequest)
        {
            try
            {
                if (commentRequest.content == "") return new Comment();

                Comment comment = new Comment(commentRequest);
                comment.created = DateTime.Now;
                Comment newComment = commentRepository.CreateEntity(comment) as Comment;
                postRepository.UpdateCommentCount(commentRequest.postId, 1);
                postRepository.UpdatePoint(commentRequest.postId, 2);
                userRepository.UpdatePoint(postRepository.GetEntityById(commentRequest.postId).userId, 2);
                this.CreateNotificationComment(newComment);
                return newComment;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete a comment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                Comment comment = commentRepository.GetEntityById(id);
                /// Delete Comment
                if (commentRepository.DeleteEntityById(id))
                {
                    /// Delete Notifications of this comment 
                    foreach (var not in notificationRepository.GetByCommentId(id))
                    {
                        notificationRepository.DeleteEntityById(not.id);
                    }
                    postRepository.UpdateCommentCount(comment.postId, -1);
                    postRepository.UpdatePoint(comment.postId, -2);
                    userRepository.UpdatePoint(postRepository.GetEntityById(comment.postId).userId, -2);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Disable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Disable(int id)
        {
            try
            {
                if (!commentRepository.EntityExist(id)) return false;
                return commentRepository.Disable(id);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Enable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Enable(int id)
        {
            try
            {
                if (!commentRepository.EntityExist(id)) return false;
                return commentRepository.Enable(id);

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Create Notification Comment
        /// </summary>
        /// <param name="comment"></param>
        private void CreateNotificationComment(Comment comment)
        {
            try
            {
                Notification notification = new Notification();
                notification.userId = postRepository.GetEntityById(comment.postId).userId;
                notification.userBId = comment.userId;
                if (notification.userId == notification.userBId) return;
                notification.created = DateTime.Now;
                notification.isReaded = false;
                notification.postId = comment.postId;
                notification.commentId = comment.id;
                notification.type = 2;

                Notification temp = notificationRepository.CreateEntity(notification) as Notification;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
