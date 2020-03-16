using MediatR;

namespace notification_services.Application.UseCases.NotificationLogs.Command.DeleteLog
{
    public class DeleteLogCommand : IRequest<DeleteLogCommandDto>
    {
        public int Id { get; set; }

        public DeleteLogCommand(int id)
        {
            Id = id;
        }
    }
}