using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using APIReviewSubject.Data;
using APIReviewSubject.Responses;
using APIReviewSubject.Services;
using Microsoft.AspNetCore.Authorization;

namespace APIReviewSubject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService profileService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ProfileController(EntityContext context) {
            profileService = new ProfileService(context);
        }

        /// <summary>
        /// Get ProfileResponse 
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("profileId={profileId}")]
        public ProfileResponse GetById(int profileId, int userId)
        {
            return profileService.GetById(profileId, userId);
        }

        /// <summary>
        /// Get History Post
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet("history={userId}")]
        public List<PostResponse> GetHistory(int profileId, int page, int userId)
        {
            return profileService.GetHistory(profileId, page, userId);
        }
    }
}
