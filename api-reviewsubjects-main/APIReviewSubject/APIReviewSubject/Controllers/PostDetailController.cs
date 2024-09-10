using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using APIReviewSubject.Data;
using APIReviewSubject.Responses;
using APIReviewSubject.Services;

namespace APIReviewSubject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostDetailController : ControllerBase
    {
        private readonly PostDetailService postDetailService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public PostDetailController(EntityContext context)
        {
            this.postDetailService = new PostDetailService(context);
        }

        /// <summary>
        /// Get Detail Post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public PostResponse GetById(int postId, int userId)
        {
            return postDetailService.GetById(postId, userId);
        }

        /// <summary>
        /// Get List Comments
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet("GetComments")]
        public List<CommentResponse> GetComments(int postId, int page)
        {
            return postDetailService.GetComments(postId, page);
        }
    }
}
