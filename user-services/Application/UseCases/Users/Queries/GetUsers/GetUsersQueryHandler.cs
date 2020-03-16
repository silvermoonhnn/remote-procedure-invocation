using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using user_services.Infrastructure;

namespace user_services.Application.UseCases.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersDto>
    {
         private readonly UserContext _context;

         public GetUsersQueryHandler(UserContext context)
         {
             _context = context;
         }

         public async Task<GetUsersDto> Handle(GetUsersQuery request, CancellationToken cancellation)
         {
            var data = await _context.Users.ToListAsync();

            return new GetUsersDto 
            {
                Success = true,
                Message = "User successfully retrieved",
                Data = data
            };
         }
    }
   


}