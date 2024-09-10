using APIReviewSubject.Requests;
using System;

namespace APIReviewSubject.Models
{
    public class Post : BaseEntity
    {
        public string subject { get; set; }
        public string teacher { get; set; }
        public int universityId { get; set; }
        public int facultyId { get; set; }
        public string? major { get; set; }
        public string? document { get; set; }
        public int rateHard { get; set; }
        public string? reviewHard { get; set; }
        public int rateLike { get; set; }
        public string? reviewLike { get; set; }
        public int rateExam { get; set; }
        public string? reviewExam { get; set; }
        public int point { get; set; }
        public int userId  { get; set; }
        public string images { get; set; }
        public int likeCount { get; set; }
        public int commentCount { get; set; }
        public Post() {}

        public Post(PostRequest postRequest)
        {
            subject = postRequest.subject;
            teacher = postRequest.teacher;
            universityId = postRequest.universityId;
            facultyId = postRequest.facultyId;
            major = postRequest.major;
            document = postRequest.document;
            rateHard = postRequest.rateHard;
            reviewHard = postRequest.reviewHard;
            rateLike = postRequest.rateLike;
            reviewLike = postRequest.reviewLike;
            rateExam = postRequest.rateExam;
            reviewExam = postRequest.reviewExam;
            userId = postRequest.userId;
            status = 1;
            images = "";
            updated = DateTime.Now;
        }
    }
}
