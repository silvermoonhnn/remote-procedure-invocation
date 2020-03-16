using MediatR;

namespace user_services.Application.UseCases.Users.Command.DeleteUser
{
    public class DeleteUserCommand : IRequest<DeleteUserCommandDto>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}