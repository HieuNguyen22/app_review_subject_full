using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Requests;
using APIReviewSubject.Services;
using APIReviewSubject.Dto;

namespace APIReviewSubject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UsersController(EntityContext context, IWebHostEnvironment webHost)
        {
            userService = new UserService(context, webHost);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public UserDto UpdateProfile(int id, UserDto userDto)
        {
            try
            {
                return userService.UpdateProfile(id, userDto);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="id"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPut("NewPassword")]
        public bool UpdatePassword(int id, Login login)
        {
            try
            {
                return userService.UpdatePassword(id, login);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Update Avatar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="avatar"></param>
        /// <returns></returns>
        [HttpPut("NewAvatar")]
        public string UpdateAvatar(int id, IFormFile avatar)
        {
            try
            {
                return userService.UpdateAvatar(id, avatar);
            } catch(Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Disable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("Disable")]
        [AllowAnonymous]
        public bool Disable(int id)
        {
            return userService.Disable(id);
        }

        /// <summary>
        /// Enable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("Enable")]
        [AllowAnonymous]
        public bool Enable(int id)
        {
            return userService.Enable(id);
        }
    }
}
