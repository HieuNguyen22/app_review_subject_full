using System.Collections.Generic;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Responses;
using System;
using System.Linq;

namespace APIReviewSubject.Services
{
    public class ProfileService
    {
        private readonly PostRepository postRepository;
        private readonly UserRepository userRepository;
        private readonly CheckActiveService check;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ProfileService(EntityContext context)
        {
            userRepository = new UserRepository(context);
            check = new CheckActiveService(context);
            postRepository = new PostRepository(context);
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ProfileResponse GetById(int profileId, int userId)
        {
            try
            {
                if (!userRepository.EntityExist(profileId) || !userRepository.EntityExist(userId))
                    return new ProfileResponse();
                return new ProfileResponse(profileId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get History
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="page"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<PostResponse> GetHistory(int profileId, int page, int userId)
        {
            try
            {
                if (!userRepository.EntityExist(profileId) || !userRepository.EntityExist(userId) || page < 1)
                    return new List<PostResponse>();
                List<PostResponse> result = new List<PostResponse>();
                List<Post> list = postRepository.GetByUserId(profileId)
                    .Where(p => check.CheckPost(p.id))
                    .OrderBy(p => p.created).Reverse().ToList();

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
