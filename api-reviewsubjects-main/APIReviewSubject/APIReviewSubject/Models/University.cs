using APIReviewSubject.Requests;
using System;

namespace APIReviewSubject.Models
{
    public class University: BaseEntity
    {
        public string name { get; set; }
        public string address { get; set; }
        public string avatar { get; set; }
        public University (){}

        public University(UniversityRequest universityRequest)
        {
            name = universityRequest.name;
            address = universityRequest.address;
            avatar = "";
            status = 1;
            updated = DateTime.Now;
        }
    }
}
