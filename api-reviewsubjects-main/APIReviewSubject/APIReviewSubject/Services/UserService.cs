using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Requests;
using System.Linq;
using APIReviewSubject.Dto;
using System.Drawing;
using System.Drawing.Imaging;

namespace APIReviewSubject.Services
{
    public class UserService
    {
        private static IWebHostEnvironment webHostEnvironment;
        private readonly UserRepository userRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UserService(EntityContext context, IWebHostEnvironment webHost)
        {
            userRepository = new UserRepository(context);
            webHostEnvironment = webHost;
        }

        /// <summary>
        /// Disable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Disable(int id)
        {
            if (!userRepository.EntityExist(id)) return false;
            return userRepository.Disable(id);
        }

        /// <summary>
        /// Enable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Enable(int id)
        {
            if (!userRepository.EntityExist(id)) return false;
            return userRepository.Enable(id);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        public UserDto UpdateProfile(int id, UserDto userDto)
        {
            try
            {
                if (!userRepository.EntityExist(id)) return new UserDto();

                User user = userRepository.GetEntityById(id);
                user.email = userDto.email;
                user.fullname = userDto.fullname;
                user.universityId = userDto.universityId;
                user.facultyId = userDto.facultyId;
                user.major = userDto.major;
                user.updated = DateTime.Now;

                userRepository.UpdateEntity(id, user);
                return new UserDto(userRepository.GetEntityById(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="id"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool UpdatePassword(int id, Login login)
        {
            try
            {
                if (!userRepository.EntityExist(id)) return false;

                User user = userRepository.GetEntityById(id);
                user.password = login.password;

                userRepository.UpdateEntity(id, user);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update avatar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="avatar"></param>
        /// <returns></returns>
        public string UpdateAvatar(int id, IFormFile avatar)
        {
            /// Check File, User
            if (!userRepository.EntityExist(id)) return "User's not exist";
            if (avatar == null) return "No File Upload!";
            string ext = Path.GetExtension(avatar.FileName);
            string[] listExt = { ".jpeg", ".jpg", ".png" };
            if (!listExt.Contains(ext.ToLower())) return "Incorrect file format!";

            string path = $"\\users\\{id}\\images\\avatar\\";
            string imgName = $"avatar_user{id}.jpg";

            /// Create Path
            if (!Directory.Exists(webHostEnvironment.WebRootPath + path))
            {
                Directory.CreateDirectory(webHostEnvironment.WebRootPath + path);
            }

            var image = Image.FromStream(avatar.OpenReadStream());

            /// Set Width height
            int maxSize = 1024;
            int width;
            int height;
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
            }

            /// Return
            User user = userRepository.GetEntityById(id);
            user.avatar = path + imgName;
            userRepository.UpdateEntity(id, user);
            return user.avatar;
        }
    }
}
