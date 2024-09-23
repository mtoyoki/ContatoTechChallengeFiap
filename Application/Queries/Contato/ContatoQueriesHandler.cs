using Domain.Queries.Contato;
using Domain.Repositories;

namespace Application.Queries.Contato
{
    public class ContatoQueriesHandlerHandler(IContatoRepository repository) : IContatoQueriesHandler
    {
        public Task<IEnumerable<ContatoQueryResult>> GetAllAsync()
        {
            return repository.GetAllAsync();
        }

        public Task<IEnumerable<ContatoQueryResult>> GetByRegiaoIdAsync(int regiaoId)
        {
            return repository.GetByRegiaoIdAsync(regiaoId);
        }
    }

    public interface IContatoQueriesHandler
    {
        Task<IEnumerable<ContatoQueryResult>> GetAllAsync();
        Task<IEnumerable<ContatoQueryResult>> GetByRegiaoIdAsync(int regiaoId);
    }
}