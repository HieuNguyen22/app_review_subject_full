using System;
using System.Collections.Generic;
using System.Linq;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Requests;

namespace APIReviewSubject.Services
{
    public class CheckActiveService
    {
        private readonly CommentRepository commentRepository;
        private readonly PostRepository postRepository;
        private readonly UserRepository userRepository;
        private readonly NotificationRepository notificationRepository;
        private readonly UniversityRepository universityRepository;
        private readonly FacultyRepository facultyRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public CheckActiveService(EntityContext context)
        {
            this.commentRepository = new CommentRepository(context);
            this.postRepository = new PostRepository(context);
            this.userRepository = new UserRepository(context);
            this.notificationRepository = new NotificationRepository(context);
            this.universityRepository = new UniversityRepository(context);
            this.facultyRepository = new FacultyRepository(context);
        }

        /// <summary>
        /// Check Faculty Active
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckFaculty(int id)
        {
            Faculty f = facultyRepository.GetEntityById(id);
            if(!this.CheckUniversity(f.universityId) || f.status != 1) return false;
            return true;
        }

        /// <summary>
        /// Check University Active
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckUniversity(int id)
        {
            if (universityRepository.GetEntityById(id).status != 1) return false;
            return true;
        }

        /// <summary>
        /// Check User Active
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckUser(int id)
        {
            User u = userRepository.GetEntityById(id);
            if (u.status != 1) return false;
            return true;
        }

        /// <summary>
        /// Check Post Active
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckPost(int id)
        {
            Post p = postRepository.GetEntityById(id);
            if (!this.CheckUser(p.userId) || !this.CheckFaculty(p.facultyId) || p.status != 1) return false;
            return true;
        }

        /// <summary>
        /// Check Comment Active
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckComment(int id)
        {
            Comment c = commentRepository.GetEntityById(id);
            if (!this.CheckPost(c.postId) || !this.CheckUser(c.userId) || c.status != 1) return false;
            return true;
        }

        /// <summary>
        /// Check Notification Active
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckNotification(int id)
        {
            Notification n = notificationRepository.GetEntityById(id);
            if (!this.CheckUser(n.userId) || !this.CheckUser(n.userBId) || !this.CheckPost(n.postId)) return false;
            if (n.commentId != 0 && !this.CheckComment(n.commentId)) return false;
            return true;
        }
    }
}
