using System.Threading;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using notification_services.Infrastructure;

namespace notification_services.Application.UseCases.Notification.Queries.GetNotification
{
    public class GetNotificationQueryHandler : IRequestHandler<GetNotificationQuery, GetNotificationDto>
    {
         private readonly NotifContext _context;

         public GetNotificationQueryHandler(NotifContext context)
         {
             _context = context;
         }

         public async Task<GetNotificationDto> Handle(GetNotificationQuery request, CancellationToken cancellation)
         {
             var result = await _context.Notifs.FirstOrDefaultAsync( i => i.Id == request.Id);

             return new GetNotificationDto
             {
                 Success = true,
                 Message = "Notification successfully retrieved",
                 Data = result
             };
         }
    }
}