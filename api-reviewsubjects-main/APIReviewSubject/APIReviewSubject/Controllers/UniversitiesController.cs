using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Requests;
using APIReviewSubject.Services;
using APIReviewSubject.Responses;
using Microsoft.AspNetCore.Cors;

namespace APIReviewSubject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly UniversityService universityService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UniversitiesController(EntityContext context, IWebHostEnvironment webHost)
        {
            this.universityService = new UniversityService(context, webHost);
        }

        /// <summary>
        /// Get all Universities
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<University> GetAll()
        {
            return universityService.GetAll();
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public University GetById(int id)
        {
            return universityService.GetById(id);
        }

        /// <summary>
        /// Create New
        /// </summary>
        /// <param name="universityRequest"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public University Create(UniversityRequest universityRequest)
        {
            return universityService.Create(universityRequest);
        }

        /// <summary>
        /// Update avatar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="avatar"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("NewAvatar")]
        [Authorize(Roles = "admin")]
        public string UpdateAvatar(int id, IFormFile avatar)
        {
            return universityService.UpdateAvatar(id, avatar);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="universityRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "admin")]
        public University EditUniversity(int id, UniversityRequest universityRequest)
        {
            try
            {
                return universityService.EditUniversity(id, universityRequest);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                return universityService.Delete(id);
            }
            catch (Exception exp)
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
        public bool Disable(int id)
        {
            return universityService.Disable(id);
        }

        /// <summary>
        /// Enable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("Enable")]
        public bool Enable(int id)
        {
            return universityService.Enable(id);
        }
    }
}
