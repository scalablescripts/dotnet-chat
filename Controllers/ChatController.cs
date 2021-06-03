using System.Threading.Tasks;
using dotnet_chat.dtos;
using Microsoft.AspNetCore.Mvc;
using PusherServer;

namespace dotnet_chat.Controllers
{
    [Route("api")]
    [ApiController]
    public class ChatController : Controller
    {
        [HttpPost("messages")]
        public async Task<ActionResult> Message(MessageDTO dto)
        {
            var options = new PusherOptions
            {
                Cluster = "",
                Encrypted = true
            };

            var pusher = new Pusher(
                "",
                "",
                "",
                options);

            await pusher.TriggerAsync(
                "chat",
                "message",
                new
                {
                    username = dto.Username,
                    message = dto.Message
                });

            return Ok(new string[] { });
        }
    }
}