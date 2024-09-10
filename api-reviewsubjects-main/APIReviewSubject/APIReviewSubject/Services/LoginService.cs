using System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Dto;
using APIReviewSubject.Responses;
using APIReviewSubject.Requests;

namespace APIReviewSubject.Services
{
    public class LoginService
    {
        private IConfiguration _config;
        private readonly UserRepository userRepository;
        private readonly AdminRepository adminRepository;
        private readonly UniversityRepository universityRepository;

        /// <summary>
        /// Constructor LoginController
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        public LoginService(EntityContext context, IConfiguration configuration)
        {
            this.userRepository = new UserRepository(context);
            this.adminRepository = new AdminRepository(context);
            this._config = configuration;
            this.universityRepository = new UniversityRepository(context);
        }

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public LoginResponse UserLogin(Login login)
        {
            LoginResponse result = new LoginResponse();
            if (!userRepository.CheckAccountExist(login.userName))
            {
                LoginResponse loginRes = new LoginResponse();
                loginRes.token = "0";
                return loginRes;
            }
            User user = userRepository.CheckLogin(login);
            
            if (user != null)
            {
                if (user.status != 1)
                {
                    LoginResponse loginRes = new LoginResponse();
                    loginRes.token = "2";
                    return loginRes;
                }
                result.token = GetToken(user);
                UserDto userDto = new UserDto(user);
                result.user = userDto;
                return result;
            }
            else
            {
                LoginResponse loginRes = new LoginResponse();
                loginRes.token = "1";
                return loginRes;
            }
        }

        /// <summary>
        /// Admin Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public AdminLoginResponse AdminLogin(Login login)
        {
            AdminLoginResponse result = new AdminLoginResponse();
            if (!adminRepository.CheckAccountExist(login.userName))
            {
                AdminLoginResponse loginRes = new AdminLoginResponse();
                loginRes.token = "0";
                return loginRes;
            }
            Admin admin = adminRepository.CheckLogin(login);

            if (admin != null)
            {
                result.token = GetToken(admin);
                AdminDto adminDto = new AdminDto(admin);
                result.admin = adminDto;
                return result;
            }
            else
            {
                AdminLoginResponse loginRes = new AdminLoginResponse();
                loginRes.token = "1";
                return loginRes;
            }
        }

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserDto Create(UserRequest userRequest)
        {
            try
            {
                if (userRepository.CheckAccountExist(userRequest.userName))
                {
                    /// Front-end Check userName exist but id == 0, so return userName Exist!
                    User user = new User();
                    user.userName = userRequest.userName.ToLower();
                    return new UserDto(user);
                }
                /// Register success
                if (userRequest.userName != "" && userRequest.password != "" && userRequest.fullname != "" &&
                    universityRepository.EntityExist(userRequest.universityId))
                {
                    User user = new User(userRequest);
                    user.created = DateTime.Now;
                    user.point = 0;

                    return new UserDto(userRepository.CreateEntity(user) as User);
                }
                /// userName, password, fullname == ""
                return new UserDto();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// get Token by User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string GetToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claimList = new[]
            {
                new Claim("id", user.id.ToString()),
                new Claim("userName", user.userName.ToString()),
            };
            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(30),
                claims: claimList,
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Get Token Admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        private string GetToken(Admin admin)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claimList = new[]
            {
                new Claim("id", admin.id.ToString()),
                new Claim(ClaimTypes.Role, "admin"),
                new Claim("userName", admin.userName.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(30),
                claims: claimList,
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
