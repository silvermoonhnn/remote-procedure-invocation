using MediatR;
using user_services.Domain.Entities;

namespace user_services.Application.UseCases.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<GetUserDto>
    {
        public int Id { get; set; }

        public GetUserQuery(int id)
        {
            Id = id;
        }
    }
}