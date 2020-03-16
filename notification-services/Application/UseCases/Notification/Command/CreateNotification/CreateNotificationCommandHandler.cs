using System;
using System.Threading;
using MediatR;
using System.Threading.Tasks;
using notification_services.Infrastructure;

namespace notification_services.Application.UseCases.Notification.Command.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, CreateNotificationCommandDto>
    {
        private readonly NotifContext _context;

        public CreateNotificationCommandHandler(NotifContext context)
        {
            _context = context;
        }

        public async Task<CreateNotificationCommandDto> Handle(CreateNotificationCommand request, CancellationToken cancellation)
        {
            var no = new Domain.Entities.NotifEn
            {
                Title = request.Data.Attributes.Title,
                Message = request.Data.Attributes.Message,
            };

             _context.Notifs.Add(no);
            await _context.SaveChangesAsync(cancellation);

            return new CreateNotificationCommandDto
            {
                Success = true,
                Message = "Notification successfully created"
            };

        }
    }
}