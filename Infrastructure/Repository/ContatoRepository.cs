using Core.Entity;
using Core.Repository;
using Infrastructure.Database;
using Microsoft.Identity.Client;

namespace Infrastructure.Repository
{
    public class ContatoRepository : EFRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IList<Contato> ListarPorDdd(int ddd)
        {
            var contatos = _context.Contato.Where(c => c.DddId == ddd).ToList();

            return contatos;
        }
    }
}