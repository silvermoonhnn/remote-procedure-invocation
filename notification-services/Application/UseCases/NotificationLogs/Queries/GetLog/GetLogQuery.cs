using MediatR;
using notification_services.Domain.Entities;

namespace notification_services.Application.UseCases.NotificationLogs.Queries.GetLog
{
    public class GetLogQuery : IRequest<GetLogDto>
    {
        public int Id { get; set; }

        public GetLogQuery(int id)
        {
            Id = id;
        }
    }
}