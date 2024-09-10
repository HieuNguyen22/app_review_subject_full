using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Responses;
using APIReviewSubject.Requests;
using APIReviewSubject.Services;
using APIReviewSubject.Dto;

namespace APIReviewSubject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService loginService;

        /// <summary>
        /// Constructor LoginController
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        public LoginController(EntityContext context, IConfiguration configuration)
        {
            this.loginService = new LoginService(context, configuration);
        }

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("UserLogin")]
        public LoginResponse UserLogin(Login login)
        {
            return loginService.UserLogin(login);
        }

        /// <summary>
        /// Admin Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("AdminLogin")]
        public AdminLoginResponse AdminLogin(Login login)
        {
            return loginService.AdminLogin(login);
        }

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public UserDto Create(UserRequest userRequest)
        {
            try
            {
                return loginService.Create(userRequest);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
