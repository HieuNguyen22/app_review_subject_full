using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.IO;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Dto;
using APIReviewSubject.Responses;
using APIReviewSubject.Requests;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;

namespace APIReviewSubject.Services
{
    public class UniversityService
    {
        private static IWebHostEnvironment webHostEnvironment;
        private readonly UniversityRepository universityRepository;
        private readonly CheckActiveService checkActiveService;
        private readonly FacultyRepository facultyRepository;
        private readonly FacultyService facultyService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UniversityService(EntityContext context, IWebHostEnvironment webHost)
        {
            universityRepository = new UniversityRepository(context);
            webHostEnvironment = webHost;
            checkActiveService = new CheckActiveService(context);
            facultyRepository = new FacultyRepository(context);
            facultyService = new FacultyService(context, webHost);
        }

        /// <summary>
        /// Get all Universities
        /// </summary>
        /// <returns></returns>
        public List<University> GetAll()
        {
            try
            {
                return universityRepository.GetAllEntity()
                    .Where(u => checkActiveService.CheckUniversity(u.id)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public University GetById(int id)
        {
            try
            {
                if (checkActiveService.CheckUniversity(id)) return universityRepository.GetEntityById(id);
                return new University();

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Create New
        /// </summary>
        /// <param name="universityRequest"></param>
        /// <returns></returns>
        public University Create(UniversityRequest universityRequest)
        {
            try
            {
                University university = new University(universityRequest);
                university.created = DateTime.Now;
                return universityRepository.CreateEntity(university) as University;

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
            try
            {
                if (!universityRepository.EntityExist(id)) return "University's not exist";
                if (avatar == null) return "No File Upload!";
                string ext = Path.GetExtension(avatar.FileName);
                string[] listExt = { ".jpeg", ".jpg", ".gif", ".png" };
                if (!listExt.Contains(ext.ToLower())) return "Incorrect file format!";

                string path = $"\\Universities\\{id}\\images\\avatar\\";
                string imgName = $"avatar_university{id}.jpg";

                var image = Image.FromStream(avatar.OpenReadStream());

                ///Create
                if (!Directory.Exists(webHostEnvironment.WebRootPath + path))
                {
                    Directory.CreateDirectory(webHostEnvironment.WebRootPath + path);
                }

                /// Set Width height
                int maxSize = 512;
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
                }

                /// Return
                University university = universityRepository.GetEntityById(id);
                university.avatar = path + imgName;
                universityRepository.UpdateEntity(id, university);
                return university.avatar;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="universityRequest"></param>
        /// <returns></returns>
        public University EditUniversity(int id, UniversityRequest universityRequest)
        {
            try
            {
                if (!universityRepository.EntityExist(id)) return new University();

                University university = universityRepository.GetEntityById(id);
                university.name = universityRequest.name;
                university.address = universityRequest.address;
                university.updated = DateTime.Now;
                universityRepository.UpdateEntity(id, university);
                return university;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                if (universityRepository.DeleteEntityById(id))
                {
                    foreach(Faculty f in facultyRepository.GetByUniversityId(id))
                    {
                        facultyService.Delete(f.id);
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
        /// Disable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Disable(int id)
        {
            try
            {
                if (!universityRepository.EntityExist(id)) return false;
                return universityRepository.Disable(id);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Enable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Enable(int id)
        {
            try
            {
                if (!universityRepository.EntityExist(id)) return false;
                return universityRepository.Enable(id);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
