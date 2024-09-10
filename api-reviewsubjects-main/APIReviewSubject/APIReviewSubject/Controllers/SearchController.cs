using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Services;
using APIReviewSubject.Responses;
using System.Collections.Generic;

namespace APIReviewSubject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SearchController : ControllerBase
    {
        private readonly SearchService searchService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public SearchController(EntityContext context)
        {
            this.searchService = new SearchService(context);
        }

        /// <summary>
        /// Get List Uni by KeySeearch
        /// </summary>
        /// <param name="keySearch"></param>
        /// <returns></returns>
        [HttpGet("university={keySearchUni}")]
        public List<University> SearchUniversity(string keySearchUni)
        {
            return searchService.SearchUniversity(keySearchUni);
        }

        /// <summary>
        /// Get List Post by keysearch
        /// </summary>
        /// <param name="keySearchSubject"></param>
        /// <returns></returns>
        [HttpGet]
        public List<PostResponse> SearchPost(int universityId, int facultyId, string keySearch, int page, int userId)
        {
            return searchService.SearchPost(universityId, facultyId, keySearch, page, userId);
        }
    }
}
