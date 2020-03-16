using System;
using notification_services.Application.Models;
using notification_services.Domain.Entities;
using MediatR;

namespace notification_services.Application.UseCases.Notification.Command.CreateNotification
{
    public class CreateNotificationCommand : RequestData<NotifEn> , IRequest<CreateNotificationCommandDto> 
    {
        
    }
}