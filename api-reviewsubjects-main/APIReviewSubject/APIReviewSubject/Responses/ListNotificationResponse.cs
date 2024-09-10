using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Data;
using APIReviewSubject.Services;
using System;
using System.Collections.Generic;

namespace APIReviewSubject.Responses
{
    public class ListNotificationResponse
    {
        public List<NotificationResponse> listNew { get; set; }
        public List<NotificationResponse> listOld { get; set; }

        /// <summary>
        /// Constructor no param
        /// </summary>
        public ListNotificationResponse() {}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="page"></param>
        public ListNotificationResponse(int userId, int page)
        {
            listNew = new List<NotificationResponse>();
            listOld = new List<NotificationResponse>();
            NotificationService notificationService = new NotificationService(new EntityContext());
            foreach(Notification notification in notificationService.GetNotifications(userId, page))
            {
                NotificationResponse notificationResponse = new NotificationResponse(notification);
                if (notificationResponse.typeTime <= 2) listNew.Add(notificationResponse);
                else listOld.Add(notificationResponse);
            }
        }
    }
}
