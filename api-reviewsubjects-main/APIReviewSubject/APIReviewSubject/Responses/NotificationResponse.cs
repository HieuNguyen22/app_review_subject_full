using APIReviewSubject.Models;
using APIReviewSubject.Repositories;
using APIReviewSubject.Data;
using System;

namespace APIReviewSubject.Responses
{
    public class NotificationResponse
    {
        public Notification notification { get; set; }
        public string userBAvatar { get; set; }
        public string userBFullname { get; set; }
        public int typeTime { get; set; }
        public int countTime { get; set; }

        /// <summary>
        /// Constructor no param
        /// </summary>
        public NotificationResponse() {}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="notification"></param>
        public NotificationResponse(Notification notification)
        {
            this.SetDefault();

            this.notification = notification;
            this.userBAvatar = new UserRepository(new EntityContext()).GetEntityById(notification.userBId).avatar;
            this.userBFullname = new UserRepository(new EntityContext()).GetEntityById(notification.userBId).fullname;
            TimeSpan temp = DateTime.Now.Subtract(notification.created);
            if(temp.TotalMinutes <= 60)
            {
                this.countTime = (int)temp.TotalMinutes;
                this.typeTime = 1;
            } else
            {
                if (temp.TotalHours <= 24)
                {
                    this.countTime = (int)temp.TotalHours;
                    this.typeTime = 2;
                } else
                {
                    this.countTime = (int)temp.TotalDays;
                    this.typeTime = 3;
                }
            }
        }

        /// <summary>
        /// Set Default value
        /// </summary>
        public void SetDefault()
        {
            this.notification = new Notification();
            this.userBAvatar = "";
            this.userBFullname = "";
            this.typeTime = 0;
            this.countTime = 0;
        }

    }
}
