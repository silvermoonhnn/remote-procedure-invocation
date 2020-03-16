using notification_services.Application.Models;
using notification_services.Domain.Entities;

namespace notification_services.Application.UseCases.Notification.Queries.GetNotification
{
    public class GetNotificationDto : BaseDto
    {
        public NotifEn Data { get; set; }
    }
}