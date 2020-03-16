using user_services.Application.Models;
using user_services.Domain.Entities;
using MediatR;

namespace user_services.Application.UseCases.Users.Command.UpdateUser
{
    public class UpdateUserCommand : RequestData<UserEn>,IRequest<UpdateUserCommandDto>
    {
        
    }
}