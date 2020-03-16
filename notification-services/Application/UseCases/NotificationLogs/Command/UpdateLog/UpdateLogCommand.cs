using notification_services.Application.Models;
using notification_services.Domain.Entities;
using MediatR;

namespace notification_services.Application.UseCases.NotificationLogs.Command.UpdateLog
{
    public class UpdateLogCommand : RequestData<LogsEn>,IRequest<UpdateLogCommandDto>
    {
        
    }
}