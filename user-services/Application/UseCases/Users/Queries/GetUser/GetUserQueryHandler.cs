using System.Threading;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using user_services.Infrastructure;

namespace user_services.Application.UseCases.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserDto>
    {
         private readonly UserContext _context;

         public GetUserQueryHandler(UserContext context)
         {
             _context = context;
         }

         public async Task<GetUserDto> Handle(GetUserQuery request, CancellationToken cancellation)
         {
             var result = await _context.Users.FirstOrDefaultAsync( i => i.Id == request.Id);

             return new GetUserDto
             {
                 Success = true,
                 Message = "User successfully retrieved",
                 Data = result
             };
         }
    }
}