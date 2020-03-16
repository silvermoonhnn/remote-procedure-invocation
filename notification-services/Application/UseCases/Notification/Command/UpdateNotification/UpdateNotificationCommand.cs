using notification_services.Application.Models;
using notification_services.Domain.Entities;
using MediatR;

namespace notification_services.Application.UseCases.Notification.Command.UpdateNotification
{
    public class UpdateNotificationCommand : RequestData<NotifEn>,IRequest<UpdateNotificationCommandDto>
    {
        
    }
}