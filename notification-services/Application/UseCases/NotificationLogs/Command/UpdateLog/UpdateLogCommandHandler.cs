using System;
using System.Threading;
using System.Threading.Tasks;
using notification_services.Infrastructure;
using MediatR;


namespace notification_services.Application.UseCases.NotificationLogs.Command.UpdateLog
{
    public class UpdateLogCommandHandler : IRequestHandler<UpdateLogCommand, UpdateLogCommandDto>
    {
        private readonly NotifContext _context;
        
        public UpdateLogCommandHandler(NotifContext context)
        {
            _context = context;
        }

        public async Task<UpdateLogCommandDto> Handle(UpdateLogCommand request, CancellationToken cancellation)
        {
            var lo = _context.Logs.Find(request.Data.Attributes.Id);
            
            lo.Notification_Id = request.Data.Attributes.Notification_Id;
            lo.Type = request.Data.Attributes.Type;
            lo.From = request.Data.Attributes.From;
            lo.Target = request.Data.Attributes.Target;
            lo.Email_Destination = request.Data.Attributes.Email_Destination;
            lo.ReadAt = request.Data.Attributes.ReadAt;

            await _context.SaveChangesAsync(cancellation);

            return new UpdateLogCommandDto
            {
                Success = true,
                Message = "Log successfully updated"
            };
        }
    }
}