using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Requests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace APIReviewSubject.Services
{
    public class PostService
    {
        private static IWebHostEnvironment webHostEnvironment;
        private readonly UserRepository userRepository;
        private readonly PostRepository postRepository;
        private readonly LikeRepository likeRepository;
        private readonly CommentRepository commentRepository;
        private readonly NotificationRepository notificationRepository;
        private readonly UniversityRepository universityRepository;
        private readonly FacultyRepository facultyRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public PostService(EntityContext context, IWebHostEnvironment webHost)
        {
            webHostEnvironment = webHost;
            this.userRepository = new UserRepository(context);
            this.postRepository = new PostRepository(context);
            this.likeRepository = new LikeRepository(context);
            this.commentRepository = new CommentRepository(context);
            this.notificationRepository = new NotificationRepository(context);
            this.universityRepository = new UniversityRepository(context);
            this.facultyRepository = new FacultyRepository(context);
        }

        /// <summary>
        /// Delete Post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                if (!postRepository.EntityExist(id)) return false;
                Post post = postRepository.GetEntityById(id);
                /// Set Status Delete Post
                if (postRepository.DeleteEntityById(id))
                {
                    ///Update User.point
                    userRepository.UpdatePoint(post.userId, post.point * (-1));
                    /// Delete Comment
                    foreach (var comment in commentRepository.GetByPostId(id))
                    {
                        commentRepository.DeleteEntityById(comment.id);
                    }
                    /// Delete Like
                    foreach (var like in likeRepository.GetByPostId(id))
                    {
                        likeRepository.DeleteEntityById(like.id);
                    }
                    /// Delete Notification
                    foreach (var not in notificationRepository.GetByPostId(id))
                    {
                        notificationRepository.DeleteEntityById(not.id);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Disable Post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Disable(int id)
        {
            try
            {
                if (!postRepository.EntityExist(id)) return false;
                return postRepository.Disable(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Enable Post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Enable(int id)
        {
            try
            {
                if (!postRepository.EntityExist(id)) return false;
                return postRepository.Enable(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="postRequest"></param>
        /// <returns></returns>
        public Post Create(PostRequest postRequest)
        {
            try
            {
                if (!userRepository.EntityExist(postRequest.userId) || postRequest.rateHard == 0 ||
                    postRequest.rateLike == 0 || postRequest.rateExam == 0 ||
                    !universityRepository.EntityExist(postRequest.universityId) ||
                    !facultyRepository.EntityExist(postRequest.facultyId))
                    return new Post();

                Post post = new Post(postRequest);
                post.point = 20;
                post.created = DateTime.Now;
                post.likeCount = 0;
                post.commentCount = 0;

                /// Update User.Point
                userRepository.UpdatePoint(post.userId, post.point);

                return postRepository.CreateEntity(post) as Post;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// UpLoad Images
        /// </summary>
        /// <param name="id"></param>
        /// <param name="images"></param>
        public string UpLoadImages(int id, List<IFormFile> files)
        {
            if (files.Count < 1) return "No file's upload";
            string result = "";
            int count = 0;

            foreach (IFormFile file in files)
            {
                /// Check File
                string ext = Path.GetExtension(file.FileName);
                string[] listExt = { ".jpeg", ".jpg", ".gif", ".png" };
                if (!listExt.Contains(ext.ToLower())) return "Incorrect file format!";
                count++;
                if (count == 6) break;
                string path = $"\\posts\\{id}\\images\\";
                string imgName = $"img_post{count}.jpg";

                /// Create Path
                if (!Directory.Exists(webHostEnvironment.WebRootPath + path))
                {
                    Directory.CreateDirectory(webHostEnvironment.WebRootPath + path);
                }

                var image = Image.FromStream(file.OpenReadStream());

                /// Set Width height
                int maxSize = 2048;
                int width = 0;
                int height = 0;
                if (image.Height <= maxSize && image.Width <= maxSize)
                {
                    width = image.Width;
                    height = image.Height;
                }
                else
                {
                    width = (image.Width >= image.Height) ? maxSize : (int)(image.Width * maxSize / image.Height);
                    height = (image.Height >= image.Width) ? maxSize : (int)(image.Height * maxSize / image.Width);
                }

                /// Convert
                var resized = new Bitmap(image, new Size(width, height));
                using var imageStream = new MemoryStream();
                resized.Save(imageStream, ImageFormat.Jpeg);
                var imageBytes = imageStream.ToArray();

                /// Save
                using (var stream = new FileStream(webHostEnvironment.WebRootPath + path + imgName, FileMode.Create, FileAccess.Write, FileShare.Write, 4096))
                {
                    stream.Write(imageBytes, 0, imageBytes.Length);
                    result += path + imgName + ",";
                }
            }

            Post post = postRepository.GetEntityById(id);
            post.images = result.Substring(0, result.Length - 1);
            postRepository.UpdateEntity(id, post);
            return post.images;
        }

        /// <summary>
        /// Update post
        /// </summary>
        /// <param name="id"></param>
        /// <param name="postRequest"></param>
        /// <returns></returns>
        public Post Update(int id, PostRequest postRequest, int userId)
        {
            try
            {
                if (!postRepository.EntityExist(id) || postRequest.userId != userId)
                    return new Post();

                Post post = postRepository.GetEntityById(id);
                post.subject = postRequest.subject;
                post.teacher = postRequest.teacher;
                post.universityId = postRequest.universityId;
                post.facultyId = postRequest.facultyId;
                post.major = postRequest.major;
                post.document = postRequest.document;
                post.rateHard = postRequest.rateHard;
                post.reviewHard = postRequest.reviewHard;
                post.rateLike = postRequest.rateLike;
                post.reviewLike = postRequest.reviewLike;
                post.rateExam = postRequest.rateExam;
                post.reviewExam = postRequest.reviewExam;
                post.updated = DateTime.Now;

                postRepository.UpdateEntity(id, post);
                return post;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
