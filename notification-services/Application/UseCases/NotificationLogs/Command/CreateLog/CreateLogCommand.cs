using System;
using notification_services.Application.Models;
using notification_services.Domain.Entities;
using MediatR;

namespace notification_services.Application.UseCases.NotificationLogs.Command.CreateLog
{
    public class CreateLogCommand : RequestData<LogsEn> , IRequest<CreateLogCommandDto> 
    {
        
    }
}