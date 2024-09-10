using System;
using System.Collections.Generic;
using System.Linq;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Requests;
using APIReviewSubject.Services;
using APIReviewSubject.Responses;

namespace APIReviewSubject.Services
{
    public class HomeService
    {
        private readonly UserRepository userRepository;
        private readonly UniversityRepository universityRepository;
        private readonly FacultyRepository facultyRepository;
        private readonly PostRepository postRepository;
        private readonly CheckActiveService check;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public HomeService(EntityContext context)
        {
            userRepository = new UserRepository(context);
            universityRepository = new UniversityRepository(context);
            facultyRepository = new FacultyRepository(context);
            postRepository = new PostRepository(context);
            check = new CheckActiveService(context);
        }

        /// <summary>
        /// Get Top Users
        /// </summary>
        /// <returns></returns>
        public List<User> GetTopUsers()
        {
            try
            {
                return userRepository.GetTopUser();

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Related Posts
        /// </summary>
        /// <param name="universityId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<PostResponse> GetRelatedPost(int universityId, int userId)
        {
            try
            {
                List<PostResponse> result = new List<PostResponse>();
                if (!universityRepository.EntityExist(universityId) ||
                    !userRepository.EntityExist(userId))
                    return result;

                List<Post> list = postRepository.GetByUniversityId(universityId)
                    .Where(p => check.CheckPost(p.id))
                    .OrderBy(p => p.point).Reverse().ToList();

                foreach (Post post in list)
                {
                    result.Add(new PostResponse(post, userId));
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get List Faculty-Post
        /// </summary>
        /// <param name="universityId"></param>
        /// <param name="page"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<FacultyPostResponse> GetListFacultyPost(int universityId, int page, int userId)
        {
            try
            {
                List<FacultyPostResponse> result = new List<FacultyPostResponse>();
                if (!universityRepository.EntityExist(universityId) ||
                    !userRepository.EntityExist(userId) || page < 1)
                    return result;

                List<Faculty> faculties = facultyRepository.GetByUniversityId(universityId)
                    .Where(f => check.CheckFaculty(f.id)).OrderBy(f => f.name).ToList();

                int length = 10;
                int start = page * length - length;
                if (start > faculties.Count()) return result;
                int count = length;
                if (start + length > faculties.Count()) count = faculties.Count() - (page - 1) * length;
                faculties = faculties.GetRange(start, count);

                foreach (Faculty faculty in faculties)
                {
                    result.Add(new FacultyPostResponse(faculty.id, 1, userId));
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
