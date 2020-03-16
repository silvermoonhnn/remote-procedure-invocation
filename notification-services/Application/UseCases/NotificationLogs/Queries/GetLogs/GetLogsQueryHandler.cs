using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using notification_services.Infrastructure;

namespace notification_services.Application.UseCases.NotificationLogs.Queries.GetLogs
{
    public class GetLogsQueryHandler : IRequestHandler<GetLogsQuery, GetLogsDto>
    {
         private readonly NotifContext _context;

         public GetLogsQueryHandler(NotifContext context)
         {
             _context = context;
         }

         public async Task<GetLogsDto> Handle(GetLogsQuery request, CancellationToken cancellation)
         {
            var data = await _context.Logs.ToListAsync();

            return new GetLogsDto 
            {
                Success = true,
                Message = "Logs successfully retrieved",
                Data = data
            };
         }
    }
   


}