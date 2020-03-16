using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using user_services.Application.UseCases.Users.Command.CreateUser;
using user_services.Application.UseCases.Users.Command.DeleteUser;
using user_services.Application.UseCases.Users.Command.UpdateUser;
using user_services.Application.UseCases.Users.Queries.GetUser;
using user_services.Application.UseCases.Users.Queries.GetUsers;

namespace user_services.Controllers
{
    [ApiController]
    [Route("user")]

    public class NotifController : ControllerBase
    {
        public IMediator _mediatr;

        public NotifController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<GetUsersDto>> GetNotif()
        {
            return Ok(await _mediatr.Send(new GetUsersQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserCommandDto>> PostNotif([FromBody] CreateUserCommand yo)
        {
            return Ok(await _mediatr.Send(yo));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDto>> GetById(int id)
        {
            return Ok(await _mediatr.Send(new GetUserQuery(id)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotif(int id, UpdateUserCommand data)
        {
            data.Data.Attributes.Id = id;

            return Ok(await _mediatr.Send(data));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotif(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediatr.Send(command);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });
        }
    }
}