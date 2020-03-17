using System.Threading;
using System.Threading.Tasks;
using notification_services.Infrastructure;
using MediatR;

namespace notification_services.Application.UseCases.Notification.Command.DeleteNotification
{
    public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, DeleteNotificationCommandDto>
    {
        private readonly NotifContext _context;

        public DeleteNotificationCommandHandler(NotifContext context)
        {
            _context = context;
        }

        public async Task<DeleteNotificationCommandDto> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Notifs.FindAsync(request.Id);
            _context.Notifs.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteNotificationCommandDto { Message = "Successfull", Success = true };
        }
    }
}