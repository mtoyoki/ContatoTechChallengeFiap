using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class RegiaoRepository : RepositoryBase<Regiao>, IRegiaoRepository
    {
        public RegiaoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}