using APIReviewSubject.Models;

namespace APIReviewSubject.Dto
{
    public class UserDto : BaseEntity
    {
        public string userName { get; set; }
        public string? email { get; set; }
        public string fullname { get; set; }
        public string avatar { get; set; }
        public int universityId { get; set; }
        public int facultyId { get; set; }
        public string? major { get; set; }
        public int point { get; set; }
        public int status { get; set; }

        public UserDto() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="user"></param>
        public UserDto(User user)
        {
            id = user.id;
            userName = user.userName;
            email = user.email;
            fullname = user.fullname;
            avatar = user.avatar;
            universityId = user.universityId;
            facultyId = user.facultyId;
            major = user.major;
            point = user.point;
            status = user.status;
            created = user.created;
            updated = user.updated;
            status = user.status;
        }
    }
}
