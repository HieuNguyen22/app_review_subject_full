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
    public class FacultyService
    {
        private readonly FacultyRepository facultyRepository;
        private readonly UniversityRepository universityRepository;
        private readonly PostRepository postRepository;
        private readonly PostService postService;
        private readonly CheckActiveService check;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public FacultyService(EntityContext context, IWebHostEnvironment webHost)
        {
            this.facultyRepository = new FacultyRepository(context);
            this.universityRepository = new UniversityRepository(context);
            this.check = new CheckActiveService(context);
            this.postRepository = new PostRepository(context);
            this.postService = new PostService(context, webHost);
        }

        /// <summary>
        /// Get By UniversityId
        /// </summary>
        /// <param name="universityId"></param>
        /// <returns></returns>
        public List<Faculty> GetByUniversityId(int universityId)
        {
            try
            {
                if (!universityRepository.EntityExist(universityId)) return new List<Faculty>();
                return facultyRepository.GetByUniversityId(universityId)
                    .Where(f => check.CheckFaculty(f.id)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Create New
        /// </summary>
        /// <param name="facultyRequest"></param>
        /// <returns></returns>
        public Faculty Create(FacultyRequest facultyRequest)
        {
            try
            {
                if (!universityRepository.EntityExist(facultyRequest.universityId)) return new Faculty();

                Faculty faculty = new Faculty(facultyRequest);
                faculty.created = DateTime.Now;
                return facultyRepository.CreateEntity(faculty) as Faculty;
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
        /// <param name="facultyRequest"></param>
        /// <returns></returns>
        public Faculty EditFaculty(int id, FacultyRequest facultyRequest)
        {
            try
            {
                if (!facultyRepository.EntityExist(id) || !universityRepository.EntityExist(facultyRequest.universityId))
                    return new Faculty();

                Faculty faculty = facultyRepository.GetEntityById(id);
                faculty.name = facultyRequest.name;
                faculty.universityId = facultyRequest.universityId;
                faculty.updated = DateTime.Now;
                facultyRepository.UpdateEntity(id, faculty);
                return faculty;
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
                if (facultyRepository.DeleteEntityById(id))
                {
                    foreach(Post p in postRepository.GetByFacultyId(id))
                    {
                        postService.Delete(p.id);
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
            if (!facultyRepository.EntityExist(id)) return false;
            return facultyRepository.Disable(id);
        }

        /// <summary>
        /// Enable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Enable(int id)
        {
            if (!facultyRepository.EntityExist(id)) return false;
            return facultyRepository.Enable(id);
        }
    }
}
