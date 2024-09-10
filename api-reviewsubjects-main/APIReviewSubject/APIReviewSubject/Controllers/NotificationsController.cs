using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Dto;
using APIReviewSubject.Responses;
using APIReviewSubject.Services;
using APIReviewSubject.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace APIReviewSubject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly NotificationService notificationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public NotificationsController(EntityContext context)
        {
            this.notificationService = new NotificationService(context);
        }

        /// <summary>
        /// Set Notification is readed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("Readed")]
        public bool Readed(int id)
        {
            return notificationService.Readed(id);
        }

        /// <summary>
        /// Get List Notifications By Page
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public ListNotificationResponse GetList(int userId, int page)
        {
            return notificationService.GetList(userId, page);
        }
    }
}
