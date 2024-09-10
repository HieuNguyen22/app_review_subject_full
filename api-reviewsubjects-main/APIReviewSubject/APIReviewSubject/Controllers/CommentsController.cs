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
    public class CommentsController : ControllerBase
    {
        private readonly CommentService commentService;

        /// <summary>
        /// Constructor CommentsController
        /// </summary>
        /// <param name="context"></param> 
        public CommentsController(EntityContext context)
        {
            this.commentService = new CommentService(context);
        }

        /// <summary>
        /// Edit Comment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commentRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Comment EditComment(int id, CommentRequest commentRequest, int userId)
        {
            return commentService.EditComment(id, commentRequest, userId);
        }
       
        /// <summary>
        /// Create new Comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost]
        public Comment Create(CommentRequest commentRequest)
        {
            return commentService.Create(commentRequest);
        }

        /// <summary>
        /// Delete a comment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return commentService.Delete(id);
        }

        /// <summary>
        /// Disable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("Disable")]
        [AllowAnonymous]
        public bool Disable(int id)
        {
            return commentService.Disable(id);
        }

        /// <summary>
        /// Enable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("Enable")]
        [AllowAnonymous]
        public bool Enable(int id)
        {
            return commentService.Enable(id);
        }
    }
}
