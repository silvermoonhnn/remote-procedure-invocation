using System;
using System.Threading;
using System.Threading.Tasks;
using notification_services.Infrastructure;
using MediatR;


namespace notification_services.Application.UseCases.Notification.Command.UpdateNotification
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, UpdateNotificationCommandDto>
    {
        private readonly NotifContext _context;
        
        public UpdateNotificationCommandHandler(NotifContext context)
        {
            _context = context;
        }

        public async Task<UpdateNotificationCommandDto> Handle(UpdateNotificationCommand request, CancellationToken cancellation)
        {
            var no = _context.Notifs.Find(request.Data.Attributes.Id);
            
            no.Title = request.Data.Attributes.Title;
            no.Message = request.Data.Attributes.Message;

            await _context.SaveChangesAsync(cancellation);

            return new UpdateNotificationCommandDto
            {
                Success = true,
                Message = "Notification successfully updated"
            };
        }
    }
}