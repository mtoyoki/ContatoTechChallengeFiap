using Application.Queries.Contato;
using Core.Commands;
using Domain.Commands.Contato;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController(
        IContatoQueryHandler contatoQueryHandler,
        ICommandHandler<ContatoCreateCommand> createCommandHandler,
        ICommandHandler<ContatoUpdateCommand> updateCommandHandler,
        ICommandHandler<ContatoDeleteCommand> deleteCommandHandler)
        : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var contatos = contatoQueryHandler.GetAllAsync().Result;

                return Ok(contatos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var contato = contatoQueryHandler.GetByIdAsync(id).Result;

                if (contato == null) return NotFound("");

                return Ok(contato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ContatoCreateCommand command)
        {
            var result = createCommandHandler.Handle(command);

            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Errors);
        }

        [HttpPut]
        public IActionResult Put([FromBody] ContatoUpdateCommand command)
        {
            var result = updateCommandHandler.Handle(command);

            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Errors);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] ContatoDeleteCommand command)
        {
            var result = deleteCommandHandler.Handle(command);

            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Errors);
        }

        [HttpGet("listar-por-ddd/{regiaoId:int}")]
        public IActionResult GetByRegiaoId([FromRoute] int regiaoId)
        {
            try
            {
                var contatos = contatoQueryHandler.GetByRegiaoIdAsync(regiaoId).Result;

                return Ok(contatos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}