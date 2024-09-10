using System.Collections.Generic;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Responses;
using System;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace APIReviewSubject.Services
{
    public class SearchService
    {
        private readonly CheckActiveService check;
        private readonly UniversityRepository universityRepository;
        private readonly PostRepository postRepository;
        private readonly FacultyRepository facultyRepository;
        private readonly UserRepository userRepository;


        public SearchService(EntityContext context)
        {
            check = new CheckActiveService(context);
            universityRepository = new UniversityRepository(context);
            postRepository = new PostRepository(context);
            facultyRepository = new FacultyRepository(context);
            userRepository = new UserRepository(context);
        }

        /// <summary>
        /// Search University
        /// </summary>
        /// <param name="keySearchUni"></param>
        /// <returns></returns>
        public List<University> SearchUniversity(string keySearchUni)
        {
            try
            {
                return universityRepository.GetByKeySearch(keySearchUni)
                .Where(u => check.CheckUniversity(u.id)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Search Post
        /// </summary>
        /// <param name="universityId"></param>
        /// <param name="facultyId"></param>
        /// <param name="keySearch"></param>
        /// <param name="page"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<PostResponse> SearchPost(int universityId, int facultyId, string keySearch, int page, int userId)
        {
            try
            {
                List<PostResponse> result = new List<PostResponse>();
                List<Post> list = new List<Post>();

                if (universityId > 0 || facultyId > 0)
                {
                    if (facultyId > 0)
                        list = postRepository.GetByFacultyId(facultyId).Where(p => check.CheckPost(p.id))
                            .OrderBy(p => p.created).Reverse().ToList();
                    else list = postRepository.GetByUniversityId(universityId).Where(p => check.CheckPost(p.id))
                            .OrderBy(p => p.created).Reverse().ToList();

                    if (!keySearch.IsNullOrEmpty())
                        list = list.Where(p => p.subject.ToLower().Contains(keySearch.ToLower()))
                            .OrderBy(p => p.subject).ToList();
                }
                else
                {
                    if (keySearch.IsNullOrEmpty()) list = postRepository.GetAllEntity().Where(p => check.CheckPost(p.id)).ToList();
                    else list = postRepository.GetByKeySearch(keySearch).Where(p => check.CheckPost(p.id)).ToList();
                }

                int length = 15;
                int start = page * length - length;
                if (start > list.Count()) return result;
                int count = length;
                if (start + length > list.Count()) count = list.Count() - (page - 1) * length;
                list = list.GetRange(start, count);

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
    }
}
