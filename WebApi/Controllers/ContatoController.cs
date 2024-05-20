using Application.Contato;
using Core.Commands;
using Domain.Commands.Contato;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoQueries _contatoQueries;
        private readonly ICommandHandler<CreateContatoCommand> _createContatoCommandHandler;
        private readonly ICommandHandler<UpdateContatoCommand> _updateContatoCommandHandler;
        private readonly ICommandHandler<DeleteContatoCommand> _deleteContatoCommandHandler;


        public ContatoController(IContatoQueries contatoQueries,
                                 ICommandHandler<CreateContatoCommand> createContatoCommandHandler,
                                 ICommandHandler<UpdateContatoCommand> updateContatoCommandHandler,
                                 ICommandHandler<DeleteContatoCommand> deleteContatoCommandHandler)
        {
            _contatoQueries = contatoQueries;
            _createContatoCommandHandler = createContatoCommandHandler;
            _updateContatoCommandHandler = updateContatoCommandHandler;
            _deleteContatoCommandHandler = deleteContatoCommandHandler;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var contatos = _contatoQueries.GetAllAsync().Result;

                return Ok(contatos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateContatoCommand command)
        {
            var result = _createContatoCommandHandler.Handle(command);

            if (result.Success)
                return Ok(result);

            return BadRequest(result.Errors);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateContatoCommand command)
        {
            var result = _updateContatoCommandHandler.Handle(command);

            if (result.Success)
                return Ok(result);

            return BadRequest(result.Errors);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteContatoCommand command)
        {
            var result = _deleteContatoCommandHandler.Handle(command);

            if (result.Success)
                return Ok(result);

            return BadRequest(result.Errors);
        }

        [HttpGet("listar-por-ddd/{regiaoId:int}")]
        public IActionResult ListarPorRegiaoId([FromRoute] int regiaoId)
        {
            try
            {
                var contatos = _contatoQueries.GetByRegiaoIdAsync(regiaoId).Result;

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