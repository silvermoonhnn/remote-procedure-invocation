using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using notification_services.Infrastructure;

namespace notification_services.Application.UseCases.Notification.Queries.GetNotifications
{
    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, GetNotificationsDto>
    {
         private readonly NotifContext _context;

         public GetNotificationsQueryHandler(NotifContext context)
         {
             _context = context;
         }

         public async Task<GetNotificationsDto> Handle(GetNotificationsQuery request, CancellationToken cancellation)
         {
            var data = await _context.Notifs.ToListAsync();

            return new GetNotificationsDto 
            {
                Success = true,
                Message = "Notification successfully retrieved",
                Data = data
            };
         }
    }
   


}