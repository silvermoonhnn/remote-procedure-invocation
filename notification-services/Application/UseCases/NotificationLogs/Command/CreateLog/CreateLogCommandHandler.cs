using System;
using System.Threading;
using MediatR;
using System.Threading.Tasks;
using notification_services.Infrastructure;

namespace notification_services.Application.UseCases.NotificationLogs.Command.CreateLog
{
    public class CreateLogCommandHandler : IRequestHandler<CreateLogCommand, CreateLogCommandDto>
    {
        private readonly NotifContext _context;

        public CreateLogCommandHandler(NotifContext context)
        {
            _context = context;
        }

        public async Task<CreateLogCommandDto> Handle(CreateLogCommand request, CancellationToken cancellation)
        {
            var lo = new Domain.Entities.LogsEn
            {
                Notification_Id = request.Data.Attributes.Notification_Id,
                Type = request.Data.Attributes.Type,
                From = request.Data.Attributes.From,
                Target = request.Data.Attributes.Target,
                Email_Destination = request.Data.Attributes.Email_Destination,
                ReadAt = request.Data.Attributes.ReadAt
            };

             _context.Logs.Add(lo);
            await _context.SaveChangesAsync(cancellation);

            return new CreateLogCommandDto
            {
                Success = true,
                Message = "Logs successfully created"
            };

        }
    }
}