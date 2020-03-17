using System;
using notification_services.Application.Models;
using notification_services.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace notification_services.Application.UseCases.Notification.Command.CreateNotification
{
    public class CreateNotificationCommand : RequestData<CreateLogs>, IRequest<CreateNotificationCommandDto> 
    {

    }

    public class CreateLogs
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public int From { get; set; }
        public List<Target> Targets { get; set; }
    }

    public class Target 
    {
        public int Id { get; set; }
        public string Email_Destination { get; set; }
    }


}