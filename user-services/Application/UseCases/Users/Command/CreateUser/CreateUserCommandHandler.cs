using System;
using System.Threading;
using MediatR;
using System.Threading.Tasks;
using user_services.Infrastructure;

namespace user_services.Application.UseCases.Users.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandDto>
    {
        private readonly UserContext _context;

        public CreateUserCommandHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<CreateUserCommandDto> Handle(CreateUserCommand request, CancellationToken cancellation)
        {
            var us = new Domain.Entities.UserEn
            {
                Name = request.Data.Attributes.Name,
                Username = request.Data.Attributes.Username,
                Email = request.Data.Attributes.Email,
                Password = request.Data.Attributes.Password,
                Address = request.Data.Attributes.Address
            };

             _context.Users.Add(us);
            await _context.SaveChangesAsync(cancellation);

            return new CreateUserCommandDto
            {
                Success = true,
                Message = "User successfully created"
            };

        }
    }
}