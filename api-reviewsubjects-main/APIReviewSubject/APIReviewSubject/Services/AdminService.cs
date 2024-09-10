using System;
using System.Collections.Generic;
using System.Linq;
using APIReviewSubject.Data;
using APIReviewSubject.Dto;
using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Requests;
using APIReviewSubject.Responses;
using Microsoft.IdentityModel.Tokens;

namespace APIReviewSubject.Services
{
    public class AdminService
    {
        private readonly PostRepository postRepository;
        private readonly UserRepository userRepository;
        private readonly UniversityRepository universityRepository;
        private readonly FacultyRepository facultyRepository;
        private readonly CommentRepository commentRepository;
        private readonly AdminRepository adminRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public AdminService(EntityContext context)
        {
            postRepository = new PostRepository(context);
            userRepository = new UserRepository(context);
            universityRepository = new UniversityRepository(context);
            facultyRepository = new FacultyRepository(context);
            commentRepository = new CommentRepository(context);
            adminRepository = new AdminRepository(context);
        }

        /// <summary>
        /// Search By Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<Admin> SearchAdmin(string key)
        {
            try
            {
                if (key.IsNullOrEmpty()) return adminRepository.GetAllEntity();
                return adminRepository.GetByKeySearch(key);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Admin GetById(int id)
        {
            try
            {
                return adminRepository.GetEntityById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="adminRequest"></param>
        /// <returns></returns>
        public AdminDto Create(AdminRequest adminRequest)
        {
            try
            {
                Admin admin = new Admin();
                if (adminRequest.userName.IsNullOrEmpty() || adminRequest.password.IsNullOrEmpty())
                    return new AdminDto();
                if (adminRepository.CheckAccountExist(adminRequest.userName))
                {
                    admin.userName = adminRequest.userName;
                    return new AdminDto(admin);
                }
                admin.userName = adminRequest.userName.ToLower();
                admin.password = adminRequest.password;
                admin.status = 1;
                admin.created = DateTime.Now;
                admin.updated = DateTime.Now;
                return new AdminDto(adminRepository.CreateEntity(admin) as Admin);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adminRequest"></param>
        /// <returns></returns>
        public bool Update(int id, AdminRequest adminRequest)
        {
            try
            {
                Admin admin = adminRepository.GetEntityById(id);
                admin.userName = adminRequest.userName;
                admin.password = adminRequest.password;

                return adminRepository.UpdateEntity(id, admin);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                if (!adminRepository.EntityExist(id)) return false;
                return adminRepository.DeleteEntityById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Universities
        /// </summary>
        /// <returns></returns>
        public List<University> GetAllUniversities()
        {
            try
            {
                return universityRepository.GetAllEntity();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Faculties By UniversityId
        /// </summary>
        /// <param name="universityId"></param>
        /// <returns></returns>
        public List<Faculty> GetFacultiesByUniversityId(int universityId)
        {
            try
            {
                return facultyRepository.GetByUniversityId(universityId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Admin Search Post
        /// </summary>
        /// <param name="status"></param>
        /// <param name="universityId"></param>
        /// <param name="facultyId"></param>
        /// <param name="userId"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        public List<PostResponse> SearchPost(int status, int universityId, int facultyId, int userId, string subject)
        {
            try
            {
                List<Post> list = postRepository.GetAllEntity();
                if (status != 0) list = list.Where(p => p.status == status).ToList();
                if (universityId != 0) list = list.Where((p) => p.universityId == universityId).ToList();
                if (facultyId != 0) list = list.Where((p) => p.facultyId == facultyId).ToList();
                if (userId != 0) list = list.Where((p) => p.userId == userId).ToList();
                if (!subject.IsNullOrEmpty()) list = list.Where(p => p.subject.ToLower().Contains(subject.ToLower())).ToList();
                List<PostResponse> result = new List<PostResponse>();
                foreach (Post post in list)
                {
                    result.Add(new PostResponse(post, 0));
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get PostResponse By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PostResponse GetPostById(int id)
        {
            try
            {
                return new PostResponse(postRepository.GetEntityById(id), 0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Admin Serach Falcuty
        /// </summary>
        /// <param name="status"></param>
        /// <param name="universityId"></param>
        /// <param name="faculty"></param>
        /// <returns></returns>
        public List<FacultyResponse> SearchFaculty(int status, int universityId, string faculty)
        {
            try
            {
                List<Faculty> list = facultyRepository.GetAllEntity();
                if (status != 0) list = list.Where(f => f.status == status).ToList();
                if (universityId != 0) list = list.Where(f => f.universityId == universityId).ToList();
                if (!faculty.IsNullOrEmpty()) list = list.Where(f => f.name.ToLower().Contains(faculty.ToLower())).ToList();

                List<FacultyResponse> result = new List<FacultyResponse>();
                foreach (Faculty f in list)
                {
                    result.Add(new FacultyResponse(f));
                }
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get FacultyResponse By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FacultyResponse GetFacultyById(int id)
        {
            try
            {
                return new FacultyResponse(facultyRepository.GetEntityById(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get UniversityResponse By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UniversityResponse GetUniversityById(int id)
        {
            try
            {
                return new UniversityResponse(universityRepository.GetEntityById(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Search University
        /// </summary>
        /// <param name="status"></param>
        /// <param name="university"></param>
        /// <returns></returns>
        public List<UniversityResponse> SearchUniversity(int status, string university)
        {
            try
            {
                List<University> list = universityRepository.GetAllEntity();
                if (status != 0) list = list.Where((f) => f.status == status).ToList();
                if (!university.IsNullOrEmpty()) list = list.Where(u => u.name.ToLower().Contains(university.ToLower())).ToList();

                List<UniversityResponse> result = new List<UniversityResponse>();

                foreach (University u in list)
                {
                    result.Add(new UniversityResponse(u));
                }
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Search Comment
        /// </summary>
        /// <param name="status"></param>
        /// <param name="userId"></param>
        /// <param name="postId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public List<CommentResponse> SearchComment(int status, int userId, int postId, string content)
        {
            try
            {
                List<Comment> list = commentRepository.GetAllEntity();
                List<CommentResponse> result = new List<CommentResponse>();

                if (status != 0) list = list.Where(c => c.status == status).ToList();
                if (userId != 0) list = list.Where(c => c.userId == userId).ToList();
                if (postId != 0) list = list.Where(c => c.postId == postId).ToList();
                if (!content.IsNullOrEmpty()) list = list.Where(c => c.content.ToLower().Contains(content.ToLower())).ToList();

                foreach (Comment c in list)
                {
                    result.Add(new CommentResponse(c));
                }

                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get CommentResponse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CommentResponse GetCommentById(int id)
        {
            try
            {
                return new CommentResponse(commentRepository.GetEntityById(id));

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Search User
        /// </summary>
        /// <param name="status"></param>
        /// <param name="universityId"></param>
        /// <param name="facultyId"></param>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public List<ProfileResponse> SearchUser(int status, int universityId, int facultyId, string fullName)
        {
            try
            {
                List<User> list = userRepository.GetAllEntity();
                List<ProfileResponse> result = new List<ProfileResponse>();

                if (status != 0) list = list.Where(u => u.status == status).ToList();
                if (universityId != 0) list = list.Where(u => u.universityId == universityId).ToList();
                if (facultyId != 0) list = list.Where(u => u.facultyId == facultyId).ToList();
                if (!fullName.IsNullOrEmpty()) list = list.Where(u => u.fullname.ToLower().Contains(fullName.ToLower())).ToList();

                foreach (User u in list)
                {
                    result.Add(new ProfileResponse(u.id, 0));
                }
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get UserResponse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProfileResponse GetUserById(int id)
        {
            try
            {
                return new ProfileResponse(id, 0);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
