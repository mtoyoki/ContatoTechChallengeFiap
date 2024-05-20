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

        public Task<IEnumerable<Domain.Entities.Contato>> GetAllAsync()
        {
            return _contatoRepository.GetAllAsync();
        }

        
        public Task<IEnumerable<Domain.Entities.Contato>> GetByRegiaoIdAsync(int regiaoId)
        {
            return _contatoRepository.GetByRegiaoIdAsync(regiaoId);
        }
    }

    public interface IContatoQueries
    {
        Task<IEnumerable<Domain.Entities.Contato>> GetAllAsync();
        Task<IEnumerable<Domain.Entities.Contato>> GetByRegiaoIdAsync(int regiaoId);
    }

}