using APIReviewSubject.Models;
using APIReviewSubject.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIReviewSubject.Responses
{
    public class LoginResponse
    {
        public string token { get; set; }
        public UserDto user { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="token"></param>
        /// <param name="user"></param>
        public LoginResponse(string token, UserDto user)
        {
            this.token = token;
            this.user = user;
        }

        public LoginResponse() { }
    }
}
