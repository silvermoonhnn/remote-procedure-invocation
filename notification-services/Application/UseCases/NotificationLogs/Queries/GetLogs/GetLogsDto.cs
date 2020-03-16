using System.Collections.Generic;
using notification_services.Application.Models;
using notification_services.Domain.Entities;

namespace notification_services.Application.UseCases.NotificationLogs.Queries.GetLogs
{
    public class GetLogsDto : BaseDto
    {
        public IList<LogsEn> Data { get; set; }
    }
}