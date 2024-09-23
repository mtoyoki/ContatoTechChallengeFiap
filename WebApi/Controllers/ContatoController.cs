using Application.Queries.Contato;
using Core.Commands;
using Domain.Commands.Contato;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoQueriesHandler _contatoQueriesHandler;
        private readonly ICommandHandler<ContatoCreateCommand> _createContatoCommandHandler;
        private readonly ICommandHandler<ContatoUpdateCommand> _updateContatoCommandHandler;
        private readonly ICommandHandler<ContatoDeleteCommand> _deleteContatoCommandHandler;


        public ContatoController(IContatoQueriesHandler contatoQueriesHandler,
                                 ICommandHandler<ContatoCreateCommand> createContatoCommandHandler,
                                 ICommandHandler<ContatoUpdateCommand> updateContatoCommandHandler,
                                 ICommandHandler<ContatoDeleteCommand> deleteContatoCommandHandler)
        {
            _contatoQueriesHandler = contatoQueriesHandler;
            _createContatoCommandHandler = createContatoCommandHandler;
            _updateContatoCommandHandler = updateContatoCommandHandler;
            _deleteContatoCommandHandler = deleteContatoCommandHandler;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var contatos = _contatoQueriesHandler.GetAllAsync().Result;

                return Ok(contatos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ContatoCreateCommand command)
        {
            var result = _createContatoCommandHandler.Handle(command);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Errors);
        }

        [HttpPut]
        public IActionResult Put([FromBody] ContatoUpdateCommand command)
        {
            var result = _updateContatoCommandHandler.Handle(command);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Errors);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] ContatoDeleteCommand command)
        {
            var result = _deleteContatoCommandHandler.Handle(command);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Errors);
        }

        [HttpGet("listar-por-ddd/{regiaoId:int}")]
        public IActionResult GetByRegiaoId([FromRoute] int regiaoId)
        {
            try
            {
                var contatos = _contatoQueriesHandler.GetByRegiaoIdAsync(regiaoId).Result;

                if (contatos == null) return NotFound();

                return Ok(contatos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}