using System;
using Microsoft.AspNetCore.Mvc;
using APIReviewSubject.Data;
using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Responses;
using System.Collections.Generic;
using System.Linq;

namespace APIReviewSubject.Services
{
    public class NotificationService
    {
        private readonly NotificationRepository notificationRepository;
        private readonly UserRepository userRepository;
        private readonly CheckActiveService check;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public NotificationService(EntityContext context)
        {
            this.notificationRepository = new NotificationRepository(context);
            this.userRepository = new UserRepository(context);
            check = new CheckActiveService(context);
        }

        /// <summary>
        /// Set Notification is readed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Readed(int id)
        {
            try
            {
                if (notificationRepository.EntityExist(id))
                {
                    Notification notification = notificationRepository.GetEntityById(id);
                    notification.isReaded = true;
                    return notificationRepository.UpdateEntity(id, notification);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get List Notifications By Page
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ListNotificationResponse GetList(int userId, int page)
        {
            if (!userRepository.EntityExist(userId) || page < 1) return new ListNotificationResponse();
            return new ListNotificationResponse(userId, page);
        }

        /// <summary>
        /// Get List Notifications
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<Notification> GetNotifications(int userId, int page)
        {
            List<Notification> list = notificationRepository.GetNotifications(userId)
                .Where(n => check.CheckNotification(n.id)).ToList();

            int length = 15;
            int start = page * length - length;
            if (start > list.Count()) return new List<Notification>();
            int count = length;
            if (start + length > list.Count()) count = list.Count() - (page - 1) * length;

            return list.GetRange(start, count);
        }
    }
}