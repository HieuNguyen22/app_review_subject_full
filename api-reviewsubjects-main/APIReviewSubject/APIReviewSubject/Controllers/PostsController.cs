using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Requests;
using APIReviewSubject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace APIReviewSubject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly PostService postService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public PostsController(EntityContext context, IWebHostEnvironment webHost)
        {
            this.postService = new PostService(context, webHost);
        }

        /// <summary>
        /// Update Post
        /// </summary>
        /// <param name="id"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Post Update(int id, PostRequest postRequest, int userId)
        {
            try
            {
                return postService.Update(id, postRequest, userId);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Create new Post
        /// </summary>
        /// <param name="postRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public Post Create(PostRequest postRequest)
        {
            try
            {
                return postService.Create(postRequest);
            } catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Upload Images
        /// </summary>
        /// <param name="id"></param>
        /// <param name="images"></param>
        /// <returns></returns>
        [HttpPut("UpLoadImages")]
        public string UpLoadImages(int id, List<IFormFile> images)
        {
            return postService.UpLoadImages(id, images);
        }

        /// <summary>
        /// Delete Post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                return postService.Delete(id);
            } catch (Exception exp)
            {
                throw exp;
            }
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
            return postService.Disable(id);
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
            return postService.Enable(id);
        }
    }
}
