using System;
using System.Threading;
using System.Threading.Tasks;
using user_services.Infrastructure;
using MediatR;


namespace user_services.Application.UseCases.Users.Command.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandDto>
    {
        private readonly UserContext _context;
        
        public UpdateUserCommandHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<UpdateUserCommandDto> Handle(UpdateUserCommand request, CancellationToken cancellation)
        {
            var yo = _context.Users.Find(request.Data.Attributes.Id);
            
            yo.Name = request.Data.Attributes.Name;
            yo.Username = request.Data.Attributes.Username;
            yo.Email = request.Data.Attributes.Email;
            yo.Address = request.Data.Attributes.Address;

            await _context.SaveChangesAsync(cancellation);

            return new UpdateUserCommandDto
            {
                Success = true,
                Message = "User successfully updated"
            };
        }
    }
}