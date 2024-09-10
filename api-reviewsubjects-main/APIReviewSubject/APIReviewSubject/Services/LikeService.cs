using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Dto;
using APIReviewSubject.Responses;
using APIReviewSubject.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace APIReviewSubject.Services
{
    public class LikeService
    {
        private LikeRepository likeRepository;
        private PostRepository postRepository;
        private UserRepository userRepository;
        private NotificationRepository notificationRepository;

        /// <summary>
        /// Constructor CommentsController
        /// </summary>
        /// <param name="context"></param> 
        public LikeService(EntityContext context)
        {
            this.likeRepository = new LikeRepository(context);
            this.notificationRepository = new NotificationRepository(context);
            this.postRepository = new PostRepository(context);
            this.userRepository = new UserRepository(context);
        }

        /// <summary>
        /// Create like
        /// </summary>
        /// <param name="likeRequest"></param>
        /// <returns></returns>
        public Like Create(LikeRequest likeRequest)
        {
            try
            {
                if (!postRepository.EntityExist(likeRequest.postId) || !userRepository.EntityExist(likeRequest.userId))
                    return new Like();

                if (likeRepository.LikePostExist(likeRequest.postId, likeRequest.userId) == 0)
                {
                    Like like = new Like(likeRequest);
                    like.created = DateTime.Now;
                    Like newLike = likeRepository.CreateEntity(like) as Like;
                    postRepository.UpdateLikeCount(likeRequest.postId, 1);
                    postRepository.UpdatePoint(likeRequest.postId, 5);
                    userRepository.UpdatePoint(postRepository.GetEntityById(likeRequest.postId).userId, 5);
                    this.CreateNotificationLike(newLike);
                    return newLike;
                }
                return new Like();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// unlike and delete old like nofication
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool UnLike(int postId, int userId)
        {
            try
            {
                if (!postRepository.EntityExist(postId) || !userRepository.EntityExist(userId))
                    return false;

                if (likeRepository.LikePostExist(postId, userId) == 0)
                    return false;

                if (likeRepository.DeleteEntityById(likeRepository.LikePostExist(postId, userId)))
                {
                    if (notificationRepository.DeleteEntityById(notificationRepository.NotificationExist(
                            postRepository.GetEntityById(postId).userId, userId, 1, postId, 0)) ||
                            postRepository.GetEntityById(postId).userId == userId)
                    {
                        postRepository.UpdateLikeCount(postId, -1);
                        postRepository.UpdatePoint(postId, -5);
                        userRepository.UpdatePoint(postRepository.GetEntityById(postId).userId, -5);
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Create Notification Like
        /// </summary>
        /// <param name="like"></param>
        private void CreateNotificationLike(Like like)
        {
            Notification notification = new Notification();
            notification.userId = postRepository.GetEntityById(like.postId).userId;
            notification.userBId = like.userId;
            if (notification.userId == notification.userBId) return;
            notification.created = DateTime.Now;
            notification.isReaded = false;
            notification.postId = like.postId;
            notification.commentId = 0;
            notification.type = 1;

            Notification temp = notificationRepository.CreateEntity(notification) as Notification;
        }
    }
}
