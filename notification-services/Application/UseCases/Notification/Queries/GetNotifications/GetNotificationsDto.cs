using System.Collections.Generic;
using notification_services.Application.Models;
using notification_services.Domain.Entities;

namespace notification_services.Application.UseCases.Notification.Queries.GetNotifications
{
    public class GetNotificationsDto : BaseDto
    {
        public IList<NotifEn> Data { get; set; }
    }
}