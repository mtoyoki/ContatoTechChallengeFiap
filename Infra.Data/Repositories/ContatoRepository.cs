using Domain.Entities;
using Domain.Queries.Contato;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
    {
        public ContatoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ContatoQueryResult>> GetAllAsync()
        {
            return await _context.Contato
                                 .Include(c => c.Regiao)
                                 .Select(c => ContatoQueryResult(c))
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<IEnumerable<ContatoQueryResult>> GetByRegiaoIdAsync(int regiaoId)
        {
            return await _context.Contato
                                 .Where(c => c.RegiaoId == regiaoId)
                                 .Include(c=> c.Regiao)
                                 .Select(c => ContatoQueryResult(c))
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        private static ContatoQueryResult ContatoQueryResult(Contato contato) => new ContatoQueryResult(contato.Id,
                                                                                                        contato.Nome,
                                                                                                        contato.Telefone,
                                                                                                        contato.Email,
                                                                                                        contato.RegiaoId,
                                                                                                        contato.Regiao.Descricao);
    }
}