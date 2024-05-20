using Domain.Entities;
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

        public async Task<IEnumerable<Contato>> GetByRegiaoIdAsync(int regiaoId)
        {
            return await _context.Contato.Where(c => c.RegiaoId == regiaoId).ToListAsync();
        }
    }
}