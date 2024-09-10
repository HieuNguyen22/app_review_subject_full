using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Requests;
using APIReviewSubject.Services;
using Microsoft.AspNetCore.Authorization;

namespace APIReviewSubject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LikesController : ControllerBase
    {
        private readonly LikeService likeService;

        /// <summary>
        /// Constructor CommentsController
        /// </summary>
        /// <param name="context"></param> 
        public LikesController(EntityContext context)
        {
            this.likeService = new LikeService(context);
        }

        /// <summary>
        /// Create like
        /// </summary>
        /// <param name="likeRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public Like Create(LikeRequest likeRequest)
        {
            return likeService.Create(likeRequest);
        }

        /// <summary>
        /// unlike and delete old like nofication
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool UnLike(int postId, int userId)
        {
            return likeService.UnLike(postId, userId);
        }
    }
}
