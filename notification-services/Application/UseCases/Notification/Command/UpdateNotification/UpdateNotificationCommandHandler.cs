using System;
using System.Threading;
using System.Threading.Tasks;
using notification_services.Infrastructure;
using MediatR;
using System.Linq;

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
            var no = _context.Logs.ToList();

            var lo = no.Where(i => i.Notification_Id == request.Data.Attributes.Notification_Id);
            foreach( var i in request.Data.Attributes.Targets)
            {
                var data = lo.First(j => j.Target == i.Id).Id;
                var dt = await _context.Logs.FindAsync(data);
                dt.ReadAt = request.Data.Attributes.ReadAt;
                await _context.SaveChangesAsync(cancellation);
            }
            
            return new UpdateNotificationCommandDto
            {
                Success = true,
                Message = "Notification successfully updated"
            };
        }
    }
}