using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Data;
using APIReviewSubject.Dto;
using System;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace APIReviewSubject.Responses
{
    public class ProfileResponse
    {
        public UserDto user { get; set; }
        public int countPost { get; set; }
        public string universityName { get; set; }
        public string facultyName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="userId"></param>
        public ProfileResponse(int profileId, int userId)
        {
            this.SetDelfault();
            EntityContext context = new EntityContext();

            this.countPost = new PostRepository(context).GetByUserId(profileId).Where(p => p.status == 1).Count();
            this.user = new UserDto(new UserRepository(context).GetEntityById(profileId));
            this.universityName = new UniversityRepository(context).GetEntityById(this.user.universityId).name;
            this.facultyName = new FacultyRepository(context).GetEntityById(this.user.facultyId).name;
        }
        public ProfileResponse() { }

        /// <summary>
        /// Set Default Value
        /// </summary>
        public void SetDelfault()
        {
            this.user = new UserDto();
            this.countPost = 0;
            this.universityName = "";
            this.facultyName = "";
        }
    }
}
