using user_services.Application.Models;
using user_services.Domain.Entities;

namespace user_services.Application.UseCases.Users.Queries.GetUser
{
    public class GetUserDto : BaseDto
    {
        public UserEn Data { get; set; }
    }
}