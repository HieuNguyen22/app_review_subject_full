using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIReviewSubject.Responses
{
    public class FacultyResponse
    {
        public Faculty faculty { get; set; }
        public string universityName { get; set; }
        public string universityAvatar { get; set; }
        public int postCount { get; set; }
        public int userCount { get; set; }

        public FacultyResponse() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="faculty"></param>
        public FacultyResponse(Faculty faculty)
        {
            this.faculty = new Faculty();
            this.universityName = "";
            this.universityAvatar = "";
            this.postCount = 0;
            this.userCount = 0;

            this.faculty = faculty;
            this.universityName = new UniversityRepository(new EntityContext()).GetEntityById(faculty.universityId).name;
            this.universityAvatar = new UniversityRepository(new EntityContext()).GetEntityById(faculty.universityId).avatar;
            this.postCount = new PostRepository(new EntityContext()).GetByFacultyId(faculty.id).Count();
            this.userCount = new UserRepository(new EntityContext()).GetByFacultyId(faculty.id).Count();
        }
    }
}
