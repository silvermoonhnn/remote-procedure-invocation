using notification_services.Application.Models;
using notification_services.Domain.Entities;

namespace notification_services.Application.UseCases.NotificationLogs.Queries.GetLog
{
    public class GetLogDto : BaseDto
    {
        public LogsEn Data { get; set; }
    }
}