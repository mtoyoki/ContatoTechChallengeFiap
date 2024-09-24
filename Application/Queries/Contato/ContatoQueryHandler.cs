using Domain.Queries.Contato;
using Domain.Repositories;

namespace Application.Queries.Contato
{
    public class ContatoQueryHandler(IContatoRepository repository) : IContatoQueryHandler
    {
        public Task<IEnumerable<ContatoQueryResult>> GetAllAsync()
        {
            return repository.GetAllAsync();
        }

        public Task<ContatoQueryResult?> GetByIdAsync(int id)
        {
            return repository.GetByIdAsync(id);
        }

        public Task<IEnumerable<ContatoQueryResult>> GetByRegiaoIdAsync(int regiaoId)
        {
            return repository.GetByRegiaoIdAsync(regiaoId);
        }
    }

    public interface IContatoQueryHandler
    {
        Task<IEnumerable<ContatoQueryResult>> GetAllAsync();
        Task<ContatoQueryResult?> GetByIdAsync(int id);
        Task<IEnumerable<ContatoQueryResult>> GetByRegiaoIdAsync(int regiaoId);
    }
}