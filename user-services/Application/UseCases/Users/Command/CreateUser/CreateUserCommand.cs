using System;
using user_services.Application.Models;
using user_services.Domain.Entities;
using MediatR;

namespace user_services.Application.UseCases.Users.Command.CreateUser
{
    public class CreateUserCommand : RequestData<UserEn> , IRequest<CreateUserCommandDto> 
    {
        
    }
}