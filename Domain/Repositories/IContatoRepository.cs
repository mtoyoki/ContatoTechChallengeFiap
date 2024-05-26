using Core.Repositories;
using Domain.Entities;
using Domain.Queries.Contato;

namespace Domain.Repositories
{
    public interface IContatoRepository : IRepository<Contato>
    {
        public Task<IEnumerable<ContatoQueryResult>> GetAsync();
        public Task<IEnumerable<ContatoQueryResult>> GetByRegiaoIdAsync(int regiaoId);        
    }
}