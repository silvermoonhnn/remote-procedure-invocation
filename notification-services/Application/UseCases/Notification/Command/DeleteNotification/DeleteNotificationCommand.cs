using MediatR;

namespace notification_services.Application.UseCases.Notification.Command.DeleteNotification
{
    public class DeleteNotificationCommand : IRequest<DeleteNotificationCommandDto>
    {
        public int Id { get; set; }

        public DeleteNotificationCommand(int id)
        {
            Id = id;
        }
    }
}