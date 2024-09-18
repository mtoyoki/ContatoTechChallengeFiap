using Domain.Queries.Contato;
using Domain.Repositories;

namespace Application.Handlers.Contato.Db
{
    public class ContatoQueriesHandlerHandler : IContatoQueriesHandler
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoQueriesHandlerHandler(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public Task<IEnumerable<ContatoQueryResult>> GetAllAsync()
        {
            return _contatoRepository.GetAllAsync();
        }

        public Task<IEnumerable<ContatoQueryResult>> GetByRegiaoIdAsync(int regiaoId)
        {
            return _contatoRepository.GetByRegiaoIdAsync(regiaoId);
        }
    }

    public interface IContatoQueriesHandler
    {
        Task<IEnumerable<ContatoQueryResult>> GetAllAsync();
        Task<IEnumerable<ContatoQueryResult>> GetByRegiaoIdAsync(int regiaoId);
    }
}