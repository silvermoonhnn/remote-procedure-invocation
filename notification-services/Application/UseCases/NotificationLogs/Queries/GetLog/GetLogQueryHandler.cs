using System.Threading;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using notification_services.Infrastructure;

namespace notification_services.Application.UseCases.NotificationLogs.Queries.GetLog
{
    public class GetLogQueryHandler : IRequestHandler<GetLogQuery, GetLogDto>
    {
         private readonly NotifContext _context;

         public GetLogQueryHandler(NotifContext context)
         {
             _context = context;
         }

         public async Task<GetLogDto> Handle(GetLogQuery request, CancellationToken cancellation)
         {
             var result = await _context.Logs.FirstOrDefaultAsync( i => i.Id == request.Id);

             return new GetLogDto
             {
                 Success = true,
                 Message = "Log successfully retrieved",
                 Data = result
             };
         }
    }
}