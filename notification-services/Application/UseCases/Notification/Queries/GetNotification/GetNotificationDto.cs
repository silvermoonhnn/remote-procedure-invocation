using notification_services.Application.Models;
using notification_services.Application.UseCases.Model;

namespace notification_services.Application.UseCases.Notification.Queries.GetNotification
{
    public class GetNotificationDto : BaseDto
    {
        public  DataNotification Data { get; set; }
    }
}