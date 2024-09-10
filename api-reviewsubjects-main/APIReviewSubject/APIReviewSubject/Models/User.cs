using APIReviewSubject.Dto;
using APIReviewSubject.Requests;
using System;

namespace APIReviewSubject.Models
{
    public class User : BaseEntity
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string? email { get; set; }
        public string fullname { get; set; }
        public string avatar { get; set; }
        public int universityId { get; set; }
        public int facultyId { get; set; }
        public string? major { get; set; }
        public int point { get; set; }

        public User() { }

        public User(UserRequest userRequest)
        {
            userName = userRequest.userName.ToLower();
            password = userRequest.password;
            email = userRequest.email;
            fullname = userRequest.fullname;
            avatar = userRequest.avatar;
            universityId = userRequest.universityId;
            facultyId = userRequest.facultyId;
            major = userRequest.major;
            status = 1;
            updated = DateTime.Now;
        }
    }
}