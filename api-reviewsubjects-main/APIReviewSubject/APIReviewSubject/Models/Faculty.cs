using APIReviewSubject.Requests;
using System;

namespace APIReviewSubject.Models
{
    public class Faculty : BaseEntity
    {
        public string name { get; set; }
        public int universityId { get; set; }
        public Faculty () {}

        public Faculty(FacultyRequest facultyRequest)
        {
            name = facultyRequest.name;
            universityId = facultyRequest.universityId;
            status = 1;
            updated = DateTime.Now;
        }
    }
}
