using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using notification_services.Application.UseCases.Notification.Command.CreateNotification;
using notification_services.Application.UseCases.Notification.Command.DeleteNotification;
using notification_services.Application.UseCases.Notification.Command.UpdateNotification;
using notification_services.Application.UseCases.Notification.Queries.GetNotification;
using notification_services.Application.UseCases.Notification.Queries.GetNotifications;

namespace notification_services.Controllers
{
    [ApiController]
    [Route("notification")]

    public class NotifController : ControllerBase
    {
        public IMediator _mediatr;

        public NotifController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<GetNotificationsDto>> GetNotif()
        {
            return Ok(await _mediatr.Send(new GetNotificationsQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<CreateNotificationCommandDto>> PostNotif([FromBody] CreateNotificationCommand yo)
        {
            return Ok(await _mediatr.Send(yo));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetNotificationDto>> GetById(int id)
        {
            return Ok(await _mediatr.Send(new GetNotificationQuery(id)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotif(int id, UpdateNotificationCommand data)
        {
            data.Data.Attributes.Id = id;

            return Ok(await _mediatr.Send(data));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotif(int id)
        {
            var command = new DeleteNotificationCommand(id);
            var result = await _mediatr.Send(command);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });
        }
    }
}