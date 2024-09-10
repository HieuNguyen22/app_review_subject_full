using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Responses;
using APIReviewSubject.Services;
using Microsoft.AspNetCore.Authorization;

namespace APIReviewSubject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        private readonly HomeService homeService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public HomeController(EntityContext context)
        {
            homeService = new HomeService(context);
        }

        /// <summary>
        /// Get Top User
        /// </summary>
        /// <returns></returns>
        [HttpGet("TopUser")]
        public List<User> GetTopUser()
        {
            return homeService.GetTopUsers();
        }

        /// <summary>
        /// Get Related Posts
        /// </summary>
        /// <param name="universityId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("RelatedPost")]
        public List<PostResponse> GetRelatedPost(int universityId, int userId)
        {
            return homeService.GetRelatedPost(universityId, userId);
        }

        /// <summary>
        /// Get List Faculty Response
        /// </summary>
        /// <param name="universityId"></param>
        /// <param name="page"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("ListPostFaculty")]
        public List<FacultyPostResponse> GetListFacultyPost(int universityId, int page, int userId)
        {
            return homeService.GetListFacultyPost(universityId, page, userId);
        }
    }
}
