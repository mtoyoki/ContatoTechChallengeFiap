using Domain.Entities;
using Domain.Queries.Contato;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
    {
        public ContatoRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<ContatoQueryResult>> GetAsync()
        {
            return await _context.Contato
                     .Include("Regiao")
                     .Select(c => ContatoQueryResult(c))
                     .ToListAsync();
        }

        public async Task<IEnumerable<ContatoQueryResult>> GetByRegiaoIdAsync(int regiaoId)
        {
            return await _context.Contato
                                 .Where(c => c.RegiaoId == regiaoId)
                                 .Include("Regiao")
                                 .Select(c => ContatoQueryResult(c))
                                 .ToListAsync();
        }
            

        private static ContatoQueryResult ContatoQueryResult(Domain.Entities.Contato contato) => new ContatoQueryResult(contato.Id,
                                                                                                                        contato.Nome,
                                                                                                                        contato.Telefone,
                                                                                                                        contato.Email,
                                                                                                                        contato.RegiaoId,
                                                                                                                        contato.Regiao.Descricao);

    }
}