using Core.Entity;

namespace Core.Repository
{
    public interface IContatoRepository : IRepository<Contato>
    {
        public IList<Contato> ListarPorDdd(int ddd);

    }
}
