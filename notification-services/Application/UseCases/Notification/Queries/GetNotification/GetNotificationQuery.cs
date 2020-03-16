using MediatR;
using notification_services.Domain.Entities;

namespace notification_services.Application.UseCases.Notification.Queries.GetNotification
{
    public class GetNotificationQuery : IRequest<GetNotificationDto>
    {
        public int Id { get; set; }

        public GetNotificationQuery(int id)
        {
            Id = id;
        }
    }
}