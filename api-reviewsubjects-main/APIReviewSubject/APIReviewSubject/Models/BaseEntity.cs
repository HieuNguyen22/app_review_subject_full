using System;

namespace APIReviewSubject.Models
{
    public class BaseEntity
    {
        public int id { get; set; }
        public int status { get; set; }
        public DateTime created { get; set; }
        public DateTime? updated { get; set; }
    }
}
