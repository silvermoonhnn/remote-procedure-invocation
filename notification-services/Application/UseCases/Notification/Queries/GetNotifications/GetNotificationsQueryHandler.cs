using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using notification_services.Infrastructure;
using System.Collections.Generic;
using notification_services.Application.UseCases.Model;

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
            var result = new List<NoData>();

            foreach (var i in data)
            {
                result.Add(new NoData
                {
                    Id = i.Id,
                    Title = i.Title,
                    Message = i.Message
                });
            }

            return new GetNotificationsDto 
            {
                Success = true,
                Message = "Notification successfully retrieved",
                Data = result
            };
         }
    }
   


}