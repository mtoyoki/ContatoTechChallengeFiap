using Core.Entity;

namespace Core.Repository
{
    public interface IContatoRepository : IRepository<Contato>
    {
        public IEnumerable<Contato> ListarPorDdd(int ddd);

    }
}
