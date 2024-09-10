using APIReviewSubject.Models;
using APIReviewSubject.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIReviewSubject.Responses
{
    public class AdminLoginResponse
    {
        public string token { get; set; }
        public AdminDto admin { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="token"></param>
        /// <param name="user"></param>
        public AdminLoginResponse(string token, AdminDto admin)
        {
            this.token = token;
            this.admin = admin;
        }

        public AdminLoginResponse() { }
    }
}
