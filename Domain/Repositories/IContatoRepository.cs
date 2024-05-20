using Core.Repositories;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IContatoRepository : IRepository<Contato>
    {
        public Task<IEnumerable<Contato>> GetByRegiaoIdAsync(int regiaoId);
    }
}