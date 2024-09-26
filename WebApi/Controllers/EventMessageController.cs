using Application.Queries.Contato;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventMessageController(IEventMessageQueryHandler eventMessageQueryHandler) : ControllerBase
    {
        [HttpGet("{eventMsgId:guid}")]
        public IActionResult Get([FromRoute] Guid eventMsgId)
        {
            try
            {
                var eventMessage = eventMessageQueryHandler.GetByEventMsgIdAsync(eventMsgId).Result;

                if (eventMessage == null) return NotFound("");

                var resultado = eventMessage.Result? "SUCESSO" : "ERRO";

                return Ok($"[{resultado}] {eventMessage.Details}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}