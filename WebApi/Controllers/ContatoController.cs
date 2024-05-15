using Core.Entity;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var contatos = _contatoRepository.GetAll();

                if (contatos == null) return NotFound();

                return Ok(contatos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var contato = _contatoRepository.GetById(id);

                if (contato == null) return NotFound();

                return Ok(contato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ContatoNewModel model)
        {
            try
            {
                var contato = new Contato()
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    Telefone = model.Telefone,
                    DddId = model.DDD
                };

                _contatoRepository.Insert(contato);

                return Ok(contato);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ContatoUpdateModel model)
        {
            try
            {
                var contato = _contatoRepository.GetById(model.Id);

                if (contato == null) return NotFound();

                contato.Nome = model.Nome;
                contato.Email = model.Email;
                contato.Telefone = model.Telefone;
                contato.DddId = model.DDD;

                _contatoRepository.Update(contato);

                return Ok(contato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var contato = _contatoRepository.GetById(id);

                if (contato == null) return NotFound();

                _contatoRepository.Delete(contato);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("listar-por-ddd/{ddd:int}")]
        public IActionResult ListarPorRegiaoId([FromRoute] int ddd)
        {
            try
            {
                var contatos = _contatoRepository.ListarPorDdd(ddd);

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