using Microsoft.AspNetCore.Mvc;
using Telebot.Services;
using Telegram.Bot.Types;

namespace Telebot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramBotController : ControllerBase
    {
        private readonly ILogger<TelegramBotController> _logger;

        public TelegramBotController(ILogger<TelegramBotController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] HandleUpdateService handleUpdateService,
                                          [FromBody] Update update)
        {
            await handleUpdateService.Handle(update);
            _logger.LogInformation($"called method {nameof(Post)}");

            return Ok();
        }
    }
}
