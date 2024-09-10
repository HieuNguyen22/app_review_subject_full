using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using APIReviewSubject.Models;
using APIReviewSubject.Data;
using APIReviewSubject.Responses;
using APIReviewSubject.Services;
using APIReviewSubject.Dto;
using APIReviewSubject.Requests;
using Microsoft.AspNetCore.Authorization;

namespace APIReviewSubject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly AdminService adminService;

        public AdminController(EntityContext context)
        {
            this.adminService = new AdminService(context);
        }

        /// <summary>
        /// Search By Key
        /// </summary>
        /// <returns></returns>
        [HttpGet("SearchAdmin")]
        public List<Admin> Search(string key)
        {
            return adminService.SearchAdmin(key);
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Admin GetById(int id)
        {
            return adminService.GetById(id);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="adminRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public AdminDto Create(AdminRequest adminRequest)
        {
            return adminService.Create(adminRequest);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adminRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public bool Update(int id, AdminRequest adminRequest)
        {
            return adminService.Update(id, adminRequest);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return adminService.Delete(id);
        }

        /// <summary>
        /// Get Universities
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllUniversities")]
        public List<University> GetAllUniversities()
        {
            return adminService.GetAllUniversities();
        }

        /// <summary>
        /// Get Faculties By UniversityId
        /// </summary>
        /// <param name="universityId"></param>
        /// <returns></returns>
        [HttpGet("GetFacultiesByUniversityId")]
        public List<Faculty> GetFacultiesByUniversityId(int universityId)
        {
            return adminService.GetFacultiesByUniversityId(universityId);
        }

        /// <summary>
        /// Search Post
        /// </summary>
        /// <param name="status"></param>
        /// <param name="universityId"></param>
        /// <param name="facultyId"></param>
        /// <param name="userId"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpGet("SearchPost")]
        public List<PostResponse> GetSearchPost(int status, int universityId, int facultyId, int userId, string subject)
        {
            return adminService.SearchPost(status, universityId, facultyId, userId, subject);
        }

        /// <summary>
        /// Get Post Response By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetPostResponseById")]
        public PostResponse GetPostById(int id)
        {
            return adminService.GetPostById(id);
        }

        /// <summary>
        /// Search Faculty
        /// </summary>
        /// <param name="status"></param>
        /// <param name="universityId"></param>
        /// <param name="faculty"></param>
        /// <returns></returns>
        [HttpGet("SearchFaculty")]
        public List<FacultyResponse> SearchFaculty(int status, int universityId, string faculty)
        {
            return adminService.SearchFaculty(status, universityId, faculty);
        }

        /// <summary>
        /// Get Faculty Response By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetFacultyResponseById")]
        public FacultyResponse GetFacultyById(int id)
        {
            return adminService.GetFacultyById(id);
        }

        /// <summary>
        /// Get UniversityResponse By Id
        /// </summary>
        /// <param name="status"></param>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        /// <returns></returns>
        [HttpGet("UniversityResponseById")]
        public UniversityResponse GetUniversityById(int id)
        {
            return adminService.GetUniversityById(id);
        }

        /// <summary>
        /// Search University
        /// </summary>
        /// <param name="status"></param>
        /// <param name="university"></param>
        /// <returns></returns>
        [HttpGet("SearchUniversity")]
        public List<UniversityResponse> SearchUniversity(int status, string university)
        {
            return adminService.SearchUniversity(status, university);
        }

        /// <summary>
        /// Search Comment
        /// </summary>
        /// <param name="status"></param>
        /// <param name="userId"></param>
        /// <param name="postId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpGet("SearchComment")]
        public List<CommentResponse> SearchComment(int status, int userId, int postId, string content)
        {
            return adminService.SearchComment(status, userId, postId, content);
        }

        /// <summary>
        /// Get CommentResponse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CommentResponseById")]
        public CommentResponse GetCommentById(int id)
        {
            return adminService.GetCommentById(id);
        }

        /// <summary>
        /// Search User
        /// </summary>
        /// <param name="status"></param>
        /// <param name="universityId"></param>
        /// <param name="facultyId"></param>
        /// <param name="fullName"></param>
        /// <returns></returns>
        [HttpGet("SearchUser")]
        public List<ProfileResponse> SearchUser(int status, int universityId, int facultyId, string fullName)
        {
            return adminService.SearchUser(status, universityId, facultyId, fullName);
        }

        /// <summary>
        /// Get UserResponseById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetUserResponse")]
        public ProfileResponse GetUserById(int id)
        {
            return adminService.GetUserById(id);
        }
    }
}
