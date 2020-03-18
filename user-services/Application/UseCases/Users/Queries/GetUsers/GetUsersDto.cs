using System.Collections.Generic;
using user_services.Application.Models;
using user_services.Domain.Entities;

namespace user_services.Application.UseCases.Users.Queries.GetUsers
{
    public class GetUsersDto : BaseDto
    {
        public List<UserEn> Data { get; set; }
    }
}