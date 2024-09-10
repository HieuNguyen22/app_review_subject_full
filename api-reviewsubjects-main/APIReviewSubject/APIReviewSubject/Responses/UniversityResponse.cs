using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIReviewSubject.Responses
{
    public class UniversityResponse
    {
        public University university { get; set; }
        public int facultyCount { get; set; }
        public int postCount { get; set; }
        public int userCount { get; set; }

        public UniversityResponse() { }

        
        public UniversityResponse(University university)
        {
            this.university = new University();
            this.facultyCount = 0;
            this.postCount = 0;
            this.userCount = 0;
            EntityContext context = new EntityContext();

            this.university = university;
            this.facultyCount = new FacultyRepository(context).GetByUniversityId(university.id).Count();
            this.postCount = new PostRepository(context).GetByUniversityId(university.id).Count();
            this.userCount = new UserRepository(context).GetByUniversityId(university.id).Count();
        }
    }
}
