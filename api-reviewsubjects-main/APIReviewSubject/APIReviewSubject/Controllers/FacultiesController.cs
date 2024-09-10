using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using APIReviewSubject.Models;
using APIReviewSubject.Data;
using APIReviewSubject.Requests;
using APIReviewSubject.Services;
using APIReviewSubject.Responses;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace APIReviewSubject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class FacultiesController : ControllerBase
    {
        private readonly FacultyService facultyService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public FacultiesController(EntityContext context, IWebHostEnvironment webHost)
        {
            this.facultyService = new FacultyService(context, webHost);
        }

        /// <summary>
        /// Get By UniversityId
        /// </summary>
        /// <param name="universityId"></param>
        /// <returns></returns>
        [HttpGet("ByUniversityId")]
        public List<Faculty> GetByUniversityId(int universityId)
        {
            return facultyService.GetByUniversityId(universityId);
        }

        /// <summary>
        /// Create New
        /// </summary>
        /// <param name="facultyRequest"></param>
        /// <returns></returns>
        /// [Authorize(Roles = "admin")]
        [HttpPost]
        public Faculty Create(FacultyRequest facultyRequest)
        {
            return facultyService.Create(facultyRequest);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="facultyRequest"></param>
        /// <returns></returns>
        /// [Authorize(Roles = "admin")]
        [HttpPut("id")]
        public Faculty EditFaculty(int id, FacultyRequest facultyRequest)
        {
            return facultyService.EditFaculty(id, facultyRequest);
        }

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// [Authorize(Roles = "admin")]
        [HttpDelete("id")]
        public bool Delete(int id)
        {
            return facultyService.Delete(id);
        }

        /// <summary>
        /// Disable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("Disable")]
        public bool Disable(int id)
        {
            return facultyService.Disable(id);
        }

        /// <summary>
        /// Enable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("Enable")]
        public bool Enable(int id)
        {
            return facultyService.Enable(id);
        }
    }
}
