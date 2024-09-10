using APIReviewSubject.Models;

namespace APIReviewSubject.Dto
{
    public class AdminDto : BaseEntity
    {
        public string userName { get; set; }

        public AdminDto() { }

        public AdminDto(Admin admin)
        {
            id = admin.id;
            userName = admin.userName;
        }
    }
}
