using System;
using System.Collections.Generic;
using System.Linq;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Requests;
using APIReviewSubject.Responses;

namespace APIReviewSubject.Services
{
    public class PostDetailService
    {
        private readonly CommentRepository commentRepository;
        private readonly PostRepository postRepository;
        private readonly UserRepository userRepository;
        private readonly CheckActiveService checkActiveService;


        public PostDetailService(EntityContext context)
        {
            commentRepository = new CommentRepository(context);
            postRepository = new PostRepository(context);
            checkActiveService = new CheckActiveService(context);
            userRepository = new UserRepository(context);
        }

        /// <summary>
        /// Get By Post Page
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<CommentResponse> GetComments(int postId, int page)
        {
            try
            {
                if (!postRepository.EntityExist(postId) || page < 1) return new List<CommentResponse>();
                List<CommentResponse> result = new List<CommentResponse>();
                List<Comment> list = commentRepository.GetByPostId(postId)
                    .Where(c => checkActiveService.CheckComment(c.id))
                    .OrderBy(c => c.created).Reverse().ToList();

                int length = 20;
                int start = page * length - length;
                if (start > list.Count()) return result;

                int count = length;
                if (start + length > list.Count()) count = list.Count() - (page - 1) * length;
                list = list.GetRange(start, count);

                foreach (Comment comment in list)
                {
                    result.Add(new CommentResponse(comment));
                }
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public PostResponse GetById(int postId, int userId)
        {
            try
            {
                if (!postRepository.EntityExist(postId) || !userRepository.EntityExist(userId))
                    return new PostResponse();
                return new PostResponse(postRepository.GetEntityById(postId), userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
