using Microsoft.AspNetCore.Mvc;
using Telebot.Services;
using Telegram.Bot.Types;

namespace Telebot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramBotController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] HandleUpdateService handleUpdateService,
                                          [FromBody] Update update)
        {
            await handleUpdateService.Handle(update);

            return Ok();
        }
    }
}
