using System.Threading;
using System.Threading.Tasks;
using notification_services.Infrastructure;
using MediatR;

namespace notification_services.Application.UseCases.NotificationLogs.Command.DeleteLog
{
    public class DeleteLogCommandHandler : IRequestHandler<DeleteLogCommand, DeleteLogCommandDto>
    {
        private readonly NotifContext _context;

        public DeleteLogCommandHandler(NotifContext context)
        {
            _context = context;
        }

        public async Task<DeleteLogCommandDto> Handle(DeleteLogCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Logs.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.Logs.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteLogCommandDto { Message = "Successfull", Success = true };
        }
    }
}