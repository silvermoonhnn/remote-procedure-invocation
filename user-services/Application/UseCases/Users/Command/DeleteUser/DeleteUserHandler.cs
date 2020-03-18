using System.Threading;
using System.Threading.Tasks;
using user_services.Infrastructure;
using MediatR;

namespace user_services.Application.UseCases.Users.Command.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserCommandDto>
    {
        private readonly UserContext _context;

        public DeleteUserCommandHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<DeleteUserCommandDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Users.FindAsync(request.Id);
            _context.Users.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteUserCommandDto { Message = "Successfull", Success = true };
        }
    }
}