using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Data;
using APIReviewSubject.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIReviewSubject.Responses
{
    public class FacultyPostResponse
    {
        public string name { get; set; }
        public List<PostResponse> posts { get; set; }

        public FacultyPostResponse() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="facultyId"></param>
        /// <param name="page"></param>
        public FacultyPostResponse(int facultyId, int page, int userId)
        {
            name = "";
            posts = new List<PostResponse>();
            EntityContext context = new EntityContext();
            CheckActiveService check = new CheckActiveService(context);
            PostRepository postRepository = new PostRepository(context);
            FacultyRepository facultyRepository = new FacultyRepository(context);

            name = facultyRepository.GetEntityById(facultyId).name;

            List<Post> list = postRepository.GetByFacultyId(facultyId)
                .OrderBy(p => p.created).Reverse()
                .Where(p => check.CheckPost(p.id)).ToList();

            int length = 15;
            int start = page * length - length;
            if (start > list.Count()) return;
            int count = length;
            if (start + length > list.Count()) count = list.Count() - (page - 1) * length;
            list = list.GetRange(start, count);

            foreach (Post post in list)
            {
                posts.Add(new PostResponse(post, userId));
            }
        }
    }
}
