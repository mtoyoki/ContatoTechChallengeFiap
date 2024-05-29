using Domain.Queries.Contato;
using Domain.Repositories;

namespace Application.Contato
{
    public class ContatoQueries : IContatoQueries
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoQueries(IContatoRepository contatoRepository)
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

    public interface IContatoQueries
    {
        Task<IEnumerable<ContatoQueryResult>> GetAllAsync();
        Task<IEnumerable<ContatoQueryResult>> GetByRegiaoIdAsync(int regiaoId);
    }
}