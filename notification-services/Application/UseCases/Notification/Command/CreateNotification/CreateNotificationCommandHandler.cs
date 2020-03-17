using System;
using System.Threading;
using MediatR;
using System.Threading.Tasks;
using notification_services.Infrastructure;
using notification_services.Domain.Entities;
using System.Linq;

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
            var noList = _context.Notifs.ToList();
            
            var no = new NotifEn
            {
                Title = request.Data.Attributes.Title,
                Message = request.Data.Attributes.Message,
            };

            if (!noList.Any(i => i.Title == request.Data.Attributes.Title))
            {
                _context.Notifs.Add(no);
            }
            await _context.SaveChangesAsync();

            var anotherno = _context.Notifs.First(i => i.Title == request.Data.Attributes.Title);
            foreach (var i in request.Data.Attributes.Targets)
            {
                _context.Logs.Add(new LogsEn
                {
                    Notification_Id = anotherno.Id,
                    Type = request.Data.Attributes.Type,
                    From = request.Data.Attributes.From,
                    Target = i.Id,
                    Email_Destination = i.Email_Destination
                });
            }
            await _context.SaveChangesAsync();

            return new CreateNotificationCommandDto
            {
                Success = true,
                Message = "Notification successfully created"
            };
        }
    }
}